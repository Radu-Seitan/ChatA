using ChatA.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace ChatA.Application.Common.Interfaces
{
    public interface IAppImageRepository
    {
        Task<AppImage> UploadImage(byte[] content, string type);
        Task DeleteImage(Guid imageId);
        Task<AppImage> GetImage(Guid imageId);
    }
}
