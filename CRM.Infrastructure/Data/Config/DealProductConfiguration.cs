using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Data.Config
{
    public class DealProductConfiguration : IEntityTypeConfiguration<DealProduct>
    {
        public void Configure(EntityTypeBuilder<DealProduct> entityTypeBuilder)
        {
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
                        Id = 21,
                        DealId = 10,
                        ProductId = 13
                    },
                    new DealProduct
                    {
                        Id = 22,
                        DealId = 10,
                        ProductId = 14
                    },
                    new DealProduct
                    {
                        Id = 23,
                        DealId = 10,
                        ProductId = 15

                    },
                    new DealProduct
                    {
                        Id = 24,
                        DealId = 10,
                        ProductId = 16
                    },
                    new DealProduct
                    {
                        Id = 25,
                        DealId = 11,
                        ProductId = 15
                    },
                    new DealProduct
                    {
                        Id = 26,
                        DealId = 12,
                        ProductId = 13
                    },
                    new DealProduct
                    {
                        Id = 27,
                        DealId = 12,
                        ProductId = 14
                    }
                );
        }
    }
}
