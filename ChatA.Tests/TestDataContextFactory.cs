using ChatA.Infrastructure.Persistence;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace ChatA.Tests
{
    public class TestDataContextFactory
    {
        private readonly DbContextOptions<AppDbContext> _options;
        public AppDbContext Create() => new AppDbContext(_options);
        public TestDataContextFactory()
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            builder.UseSqlite(connection);

            using (var ctx = new AppDbContext(builder.Options))
            {
                ctx.Database.EnsureCreated();
            }

            _options = builder.Options;
        }
    }
}
