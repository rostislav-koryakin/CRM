using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Data.Config
{
    public class DealProductConfiguration : BaseEntityConfiguration<DealProduct>
    {
        public override void Configure(EntityTypeBuilder<DealProduct> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder
                .Property(dp => dp.Quantity)
                .IsRequired();

            entityTypeBuilder
                .HasOne(dp => dp.Deal)
                .WithMany(d => d.DealsProducts)
                .HasForeignKey(dp => dp.DealId)
                .OnDelete(DeleteBehavior.Cascade);

            entityTypeBuilder
                .HasOne(dp => dp.Product)
                .WithMany(p => p.DealsProducts)
                .HasForeignKey(dp => dp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            entityTypeBuilder
                .HasData(
                    new DealProduct
                    {
                        Quantity = 2,
                        Id = 1,
                        DealId = 1,
                        ProductId = 1
                    },
                    new DealProduct
                    {
                        Quantity = 1,
                        Id = 2,
                        DealId = 1,
                        ProductId = 2
                    },
                    new DealProduct
                    {
                        Quantity = 3,
                        Id = 3,
                        DealId = 1,
                        ProductId = 3

                    },
                    new DealProduct
                    {
                        Quantity = 1,
                        Id = 4,
                        DealId = 1,
                        ProductId = 4
                    },
                    new DealProduct
                    {
                        Quantity = 2,
                        Id = 5,
                        DealId = 2,
                        ProductId = 2
                    },
                    new DealProduct
                    {
                        Quantity = 3,
                        Id = 6,
                        DealId = 3,
                        ProductId = 3
                    },
                    new DealProduct
                    {
                        Quantity = 3,
                        Id = 7,
                        DealId = 3,
                        ProductId = 4
                    },
                    new DealProduct
                    {
                        Quantity = 3,
                        Id = 8,
                        DealId = 4,
                        ProductId = 5
                    }
                );
        }
    }
}
