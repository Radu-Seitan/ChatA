using ChatA.Application.Common.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChatA.Application.Images.Commands
{
    public class UploadImageCommand : IRequest<Guid>
    {
        public byte[] Content { get; set; }
        public string Type { get; set; }
    }

    public class UploadImageCommandHandler : IRequestHandler<UploadImageCommand, Guid>
    {
        private readonly IAppImageRepository _appImageRepository;
        public UploadImageCommandHandler(IAppImageRepository appImageRepository)
        {
            _appImageRepository = appImageRepository;
        }
        public async Task<Guid> Handle(UploadImageCommand request, CancellationToken cancellationToken)
        {
            var image = await _appImageRepository.UploadImage(request.Content, request.Type);
            return image.Id;
        }
    }
}
