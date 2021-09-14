using ChatA.Application.Users.Commands;
using ChatA.Application.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace ChatA.WebUI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator, ILogger logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> PostUser([FromBody] CreateUserCommand command)
        {
            var user = await _mediator.Send(command);
            return Ok();
        }
    }
}
