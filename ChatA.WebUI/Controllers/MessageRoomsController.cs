using ChatA.Application.MessageRooms.Commands;
using ChatA.Application.MessageRooms.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChatA.WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MessageRoomsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public MessageRoomsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize]
        public async Task<ActionResult> PostIndividualMessageRoom([FromBody] CreateIndividualMessageRoomCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize]
        public async Task<ActionResult> PostGroupMessageRoom([FromBody] CreateGroupMessageRoomCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[Authorize]
        public async Task<ActionResult> PutUserInRoom([FromBody] AddUserToGroupMessageRoomCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<MessageRoomViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IEnumerable<MessageRoomViewModel>>> GetUsers([FromRoute] string id)
        {
            var query = new GetMessageRoomsQuery { UserId = id };
            var rooms = await _mediator.Send(query);
            return rooms is null ? NotFound() : Ok(rooms);
        }
    }
}
