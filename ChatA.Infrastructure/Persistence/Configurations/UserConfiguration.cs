using ChatA.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatA.Infrastructure.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(t => t.Id).IsRequired();
            builder.Property(t => t.Username)
                .HasMaxLength(40)
                .IsRequired();
            builder.Property(t => t.Email)
                .HasMaxLength(40)
                .IsRequired();
            builder.HasData(
                new User { Email = "raducseitan@gmail.com", Id = "google-oauth2|109835840698705157612", Username = "Radu Seitan" }
                //new User { Email = "raducseitan@gmail.com", Id = "google-oauth2|109835840698705157612", Username = "Radu Seitan" }
                );
        }
    }
}
