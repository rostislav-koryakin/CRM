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
                .HasKey(dp => dp.Id);

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
        }
    }
}
