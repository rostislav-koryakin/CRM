using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Data.Config
{
    public class SalesmanConfiguration : IEntityTypeConfiguration<Salesman>
    {
        public void Configure(EntityTypeBuilder<Salesman> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasKey(s => s.Id);

            entityTypeBuilder
                .Property(s => s.FirstName)
                .IsRequired()
                .HasColumnType("varchar(127)");

            entityTypeBuilder
                .Property(s => s.LastName)
                .IsRequired()
                .HasColumnType("varchar(127)");

            entityTypeBuilder
                .Property(s => s.Phone)
                .HasColumnType("varchar(15)");

            entityTypeBuilder
                .Property(s => s.Email)
                .IsRequired()
                .HasColumnType("varchar(127)");

            entityTypeBuilder
                .HasIndex(s => new { s.FirstName, s.LastName });
        }
    }
}
