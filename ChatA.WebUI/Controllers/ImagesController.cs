using ChatA.Application.Common.Interfaces;
using ChatA.Application.Images.Commands;
using ChatA.Application.Images.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace ChatA.WebUI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class ImagesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ImagesController(IMediator mediator, ICurrentUserService currentUserService)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] IFormFile file)
        {
            if (file != null)
            {
                if (file.Length > 0)
                {
                    var contentType = Request.Headers["content"].ToString();
                    Console.WriteLine(file.ContentType);
                    byte[] content = null;
                    using (var fileStream = file.OpenReadStream())
                    using (var memoryStream = new MemoryStream())
                    {
                        fileStream.CopyTo(memoryStream);
                        content = memoryStream.ToArray();
                    }

                    var command = new UploadImageCommand
                    {
                        Content = content,
                        Type = contentType
                    };
                    var imageId = await _mediator.Send(command);
                    return Ok(imageId);
                }
                else return BadRequest("file length");
            }
            else return BadRequest("file[0] is null");
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var query = new GetImageQuery
            {
                ImageId = id
            };
            var image = await _mediator.Send(query);

            return File(image.Content, $"{image.Type}");
        }
    }
}
