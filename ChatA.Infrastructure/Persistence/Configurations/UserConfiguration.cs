﻿using ChatA.Domain.Entities;
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
                    new User { Email = "raducseitan@gmail.com", Id = "google-oauth2|109835840698705157612", Username = "Radu Seitan" },
                    new User { Email = "stefan.oproiu@amdaris.com", Id = "google-oauth2|101710427757368652279", Username = "Stefan Oproiu" },
                    new User { Email = "radu.seitan@amdaris.com", Id = "auth0|6149784cde45d300692a99b3", Username = "radu.seitan@amdaris.com" }
                );
        }
    }
}
