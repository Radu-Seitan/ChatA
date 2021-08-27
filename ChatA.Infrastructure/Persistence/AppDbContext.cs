using ChatA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ChatA.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageRoom> MessageRooms { get; set; }
        public DbSet<GroupMembership> GroupMemberships { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            builder.Entity<IndividualMessageRoom>();
            builder.Entity<GroupMessageRoom>();

            base.OnModelCreating(builder); 
        }
    }
}
