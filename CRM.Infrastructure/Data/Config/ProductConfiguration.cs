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

            entityTypeBuilder
                .HasData(
                    new Product
                    {
                        Id = 1,
                        Name = "Digital Marketing",
                        Price = 10000.0M
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Branding",
                        Price = 20000.0M
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Content Creation",
                        Price = 30000.0M
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Strategic Planning",
                        Price = 40000.0M
                    }
                );
        }
    }
}
