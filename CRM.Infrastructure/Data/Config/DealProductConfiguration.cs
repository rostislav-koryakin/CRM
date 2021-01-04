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
                .OnDelete(DeleteBehavior.Restrict);

            entityTypeBuilder
                .HasOne(dp => dp.Product)
                .WithMany(p => p.DealsProducts)
                .HasForeignKey(dp => dp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            entityTypeBuilder
                .HasData(
                    new DealProduct
                    {
                        Id = 1,
                        DealId = 1,
                        ProductId = 1
                    },
                    new DealProduct
                    {
                        Id = 2,
                        DealId = 1,
                        ProductId = 2
                    },
                    new DealProduct
                    {
                        Id = 3,
                        DealId = 1,
                        ProductId = 3

                    },
                    new DealProduct
                    {
                        Id = 4,
                        DealId = 1,
                        ProductId = 4
                    },
                    new DealProduct
                    {
                        Id = 5,
                        DealId = 2,
                        ProductId = 2
                    },
                    new DealProduct
                    {
                        Id = 6,
                        DealId = 3,
                        ProductId = 3
                    },
                    new DealProduct
                    {
                        Id = 7,
                        DealId = 3,
                        ProductId = 4
                    },
                    new DealProduct
                    {
                        Id = 8,
                        DealId = 4,
                        ProductId = 5
                    }
                );
        }
    }
}
