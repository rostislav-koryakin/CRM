using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Data.Config
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasKey(c => c.Id);

            entityTypeBuilder
                .Property(c => c.TaxpayerNumber)
                .IsRequired()
                .HasColumnType("varchar(15)");

            entityTypeBuilder
                .Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(127)");

            entityTypeBuilder
                .Property(c => c.City)
                .HasColumnType("varchar(127)");

            entityTypeBuilder
                .Property(c => c.Street)
                .HasColumnType("varchar(127)");

            entityTypeBuilder
                .Property(c => c.ZipCode)
                .HasColumnType("varchar(15)");

            entityTypeBuilder
                .HasIndex(c => c.TaxpayerNumber)
                .IsUnique();
        }
    }
}
