using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Data.Config
{
    public class BaseEntityConfiguration : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> entityTypeBuilder)
        {
            entityTypeBuilder
                .ToTable("BaseEntity")
                .HasDiscriminator<string>("EntityType")
                .HasValue<Activity>(nameof(Activity))
                .HasValue<Company>(nameof(Company))
                .HasValue<Contact>(nameof(Contact))
                .HasValue<Deal>(nameof(Deal))
                .HasValue<DealProduct>(nameof(DealProduct))
                .HasValue<Product>(nameof(Product))
                .HasValue<Salesman>(nameof(Salesman));

            entityTypeBuilder
                .HasKey(e => e.Id);

            entityTypeBuilder
                .Property(e => e.CreatedDate)
                .HasColumnName("Created Date");

            entityTypeBuilder
                .Property(e => e.UpdatedDate)
                .HasColumnName("Updated Date");
        }
    }
}
