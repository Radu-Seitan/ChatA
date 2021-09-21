using ChatA.Application.Common.Interfaces;
using ChatA.Application.Messages.Commands;
using ChatA.Application.Messages.Queries;
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
    [Route("[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUserService;
        public MessagesController(IMediator mediator, ICurrentUserService currentUserService)
        {
            _mediator = mediator;
            _currentUserService = currentUserService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
        public async Task<ActionResult> PostMessage([FromBody] CreateMessageModel messageModel)
        {
            var command = new CreateMessageCommand { 
                RoomId = messageModel.RoomId, 
                Text = messageModel.Text, 
                SenderId = _currentUserService.UserId
            };
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<MessageViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<MessageViewModel>>> GetMessages([FromRoute] int id)
        {
            var query = new GetAllMessagesQuery { MessageRoomId = id }; 
            var messages = await _mediator.Send(query);
            return messages is null ? NotFound() : Ok(messages);
        }
    }
}
