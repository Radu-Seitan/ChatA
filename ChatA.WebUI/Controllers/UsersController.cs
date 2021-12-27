using ChatA.Application.Common.Interfaces;
using ChatA.Application.Users.Commands;
using ChatA.Application.Users.Queries;
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
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserService _currentUserService;
        public UsersController(IMediator mediator, ICurrentUserService currentUserService)
        {
            _mediator = mediator;
            _currentUserService = currentUserService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> PostUser([FromBody] CreateUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserViewModel),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult<UserViewModel>> GetUser([FromRoute] string id)
        {
            var query = new GetSingleUserQuery { Id = id };
            var user = await _mediator.Send(query);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers([FromQuery] SearchAllUsersQuery query)
        {
            var users = await _mediator.Send(query);
            return users is null ? NotFound() : Ok(users);
        }

        [HttpGet("MessageRooms/{roomId}")]
        [ProducesResponseType(typeof(IEnumerable<UserViewModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsersInRoom([FromRoute] int roomId)
        {
            var query = new GetUsersInRoomQuery { RoomId = roomId };
            var users = await _mediator.Send(query);
            return users is null ? NotFound() : Ok(users);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> ChangeUserDetails(ChangeUserDetailsCommandModel commandModel)
        {
            var command = new ChangeUserDetailsCommand
            {
                Id = _currentUserService.UserId,
                Username = commandModel.Username,
                Email = commandModel.Email
            };
            await _mediator.Send(command);
            return Ok();
        }
    }
}
