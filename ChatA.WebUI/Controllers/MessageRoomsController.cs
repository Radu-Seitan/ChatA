using ChatA.Application.Common.Interfaces;
using ChatA.Application.MessageRooms.Commands;
using ChatA.Application.MessageRooms.Queries;
using ChatA.WebUI.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatA.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MessageRoomsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUserService;
        public MessageRoomsController(IMediator mediator, ICurrentUserService currentUserService)
        {
            _mediator = mediator;
            _currentUserService = currentUserService;
        }

        [HttpPost]
        [Route("individual")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PostIndividualMessageRoom([FromBody] CreateIndividualMessageRoomModel commandModel)
        {
            var command = new CreateIndividualMessageRoomCommand {FirstUserId = _currentUserService.UserId, SecondUserId = commandModel.SecondUserId};
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        [Route("group")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PostGroupMessageRoom([FromBody] CreateGroupMessageRoomModel commandModel)
        {
            var command = new CreateGroupMessageRoomCommand { OwnerId = _currentUserService.UserId, Name = commandModel.Name };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PutUserInRoom([FromBody] AddUserToGroupMessageRoomModel commandModel)
        {
            var command = new AddUserToGroupMessageRoomCommand { 
                OwnerId = _currentUserService.UserId, 
                RoomId = commandModel.RoomId, 
                UserId = commandModel.UserId 
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<MessageRoomViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<MessageRoomViewModel>>> GetMessageRooms([FromRoute] string id)
        {
            var query = new GetMessageRoomsQuery { UserId = id };
            var rooms = await _mediator.Send(query);
            return rooms is null ? NotFound() : Ok(rooms);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteMessageRoom([FromRoute] int id)
        {
            var command = new DeleteMessageRoomCommand {
                RoomId = id,
                UserId = _currentUserService.UserId
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        [Route("leave/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> LeaveGroup([FromRoute] int id)
        {
            var command = new LeaveGroupMessageRoomCommand
            {
                RoomId = id,
                UserId = _currentUserService.UserId
            };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
