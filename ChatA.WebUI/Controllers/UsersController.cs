using ChatA.Application.Users.Commands;
using ChatA.Application.Users.Queries;
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
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [Authorize]
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
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetUsers([FromBody] SearchAllUsersQuery query)
        {
            var users = await _mediator.Send(query);
            return users is null ? NotFound() : Ok(users);
        }
    }
}
