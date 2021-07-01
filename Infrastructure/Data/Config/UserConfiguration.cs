using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.UserName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.PasswordHash).IsRequired();
            builder.Property(p => p.UserName).IsRequired();
        }
    }
}