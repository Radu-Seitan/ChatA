using ChatA.Application.Common.Interfaces;
using ChatA.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ChatA.Application.Images.Queries
{
    public class GetImageQuery : IRequest<AppImage>
    {
        public Guid ImageId { get; set; }
    }

    public class GetImageQueryHandler : IRequestHandler<GetImageQuery,AppImage>
    {
        private readonly IAppImageRepository _appImageRepository;
        public GetImageQueryHandler(IAppImageRepository appImageRepository)
        {
            _appImageRepository = appImageRepository;
        }

        public async Task<AppImage> Handle(GetImageQuery request, CancellationToken cancellationToken)
        {
            return await _appImageRepository.GetImage(request.ImageId);
        }
    }
}
