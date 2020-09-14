using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Data.Config
{
    public class DealConfiguration : IEntityTypeConfiguration<Deal>
    {
        public void Configure(EntityTypeBuilder<Deal> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasKey(d => d.Id);

            entityTypeBuilder
                .Property(d => d.Name)
                .IsRequired()
                .HasColumnType("varchar(127)");

            entityTypeBuilder
                .Property(d => d.TotalAmount)
                .HasColumnType("decimal(18, 2)");

            entityTypeBuilder
                .Property(d => d.Stage)
                .HasConversion<string>();

            entityTypeBuilder
                .Property(d => d.Description)
                .HasColumnType("varchar(255)");

            entityTypeBuilder
                .HasOne(d => d.Contact)
                .WithMany(c => c.Deals)
                .HasForeignKey(d => d.ContactId)
                .OnDelete(DeleteBehavior.Restrict);

            entityTypeBuilder
                .HasOne(d => d.Company)
                .WithMany(c => c.Deals)
                .HasForeignKey(d => d.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

            entityTypeBuilder
                .HasOne(d => d.Salesman)
                .WithMany(s => s.Deals)
                .HasForeignKey(d => d.SalesmanId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
