using CRM.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Web.Data.Config
{
    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> entityTypeBuilder)
        {
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
