using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CRM.Infrastructure.Data.Config
{
    public class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

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
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        Name = "Digital Marketing",
                        Price = 10000.0M
                    },
                    new Product
                    {
                        Id = 2,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        Name = "Branding",
                        Price = 20000.0M
                    },
                    new Product
                    {
                        Id = 3,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        Name = "Content Creation",
                        Price = 30000.0M
                    },
                    new Product
                    {
                        Id = 4,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        Name = "Strategic Planning",
                        Price = 40000.0M
                    },
                    new Product
                    {
                        Id = 5,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        Name = "Rebranding",
                        Price = 10000.0M
                    }
                );
        }
    }
}
