using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(500);
            builder.HasOne(e => e.Exchange).WithMany()
                .HasForeignKey(c => c.ExchangeId);
            builder.Property(p => p.Ticker).IsRequired().HasMaxLength(100);
            builder.HasIndex(p => p.ISIN, "UniqueCOL1").IsUnique(true);
            builder.Property(p => p.ISIN).IsRequired().HasMaxLength(100);;
            builder.Property(p => p.Website).HasMaxLength(1000);
        }
    }
}