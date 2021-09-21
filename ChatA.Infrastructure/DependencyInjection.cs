using ChatA.Application.Common.Interfaces;
using ChatA.Infrastructure.Persistence;
using ChatA.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatA.Infrastructure
{
    public static class DependencyInjection 
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IMessageRoomRepository, MessageRoomRepository>();
            services.AddTransient<IMessageRepository, MessageRepository>();
            return services;
        }
    }
}
