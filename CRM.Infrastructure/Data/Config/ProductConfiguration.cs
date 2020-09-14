using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasKey(p => p.Id);

            entityTypeBuilder
                .Property(p => p.Name)
                .IsRequired()
                .HasColumnType("varchar(127)");

            entityTypeBuilder
                .Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            entityTypeBuilder
                .HasIndex(p => p.Name)
                .IsUnique();
        }
    }
}
