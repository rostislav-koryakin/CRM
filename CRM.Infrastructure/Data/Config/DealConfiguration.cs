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

            entityTypeBuilder
                .HasData(
                    new Deal
                    {
                        Id = 10,
                        CompanyId = 6,
                        ContactId = 9,
                        SalesmanId = 17,
                        Name = "Newman Project",
                        TotalAmount = 1000000.0M,
                        Description = "Description",
                        Stage = Deal.DealStage.New
                    },
                    new Deal
                    {
                        Id = 11,
                        CompanyId = 5,
                        ContactId = 7,
                        SalesmanId = 18,
                        Name = "The Stones Project X",
                        TotalAmount = 929301.0M,
                        Description = "Description",
                        Stage = Deal.DealStage.Ongoing
                    },
                    new Deal
                    {
                        Id = 12,
                        CompanyId = 8,
                        ContactId = 7,
                        SalesmanId = 20,
                        Name = "The Stones Project Y",
                        TotalAmount = 20039499.0M,
                        Description = "Description",
                        Stage = Deal.DealStage.New
                    }
                );
        }
    }
}
