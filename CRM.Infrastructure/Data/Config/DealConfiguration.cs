using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CRM.Infrastructure.Data.Config
{
    public class DealConfiguration : BaseEntityConfiguration<Deal>
    {
        public override void Configure(EntityTypeBuilder<Deal> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder
                .Property(d => d.Name)
                .IsRequired()
                .HasColumnType("varchar(127)");

            entityTypeBuilder
                .Property(d => d.TotalAmount)
                .HasColumnType("decimal(18, 2)");

            entityTypeBuilder
                .Property(d => d.Description)
                .HasColumnType("varchar(255)");

            entityTypeBuilder
                .Property(d => d.ClosingDate)
                .HasColumnName("Closing Date");

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
                        Id = 1,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        CompanyId = 2,
                        ContactId = 2,
                        SalesmanId = 1,
                        Name = "Newman Project",
                        TotalAmount = 1000000.0M,
                        Description = "Description",
                        Stage = Deal.DealStage.New
                    },
                    new Deal
                    {
                        Id = 2,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        CompanyId = 1,
                        ContactId = 1,
                        SalesmanId = 2,
                        Name = "The Stones Project X",
                        TotalAmount = 929301.0M,
                        Description = "Description",
                        Stage = Deal.DealStage.Analisis
                    },
                    new Deal
                    {
                        Id = 3,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        CompanyId = 1,
                        ContactId = 1,
                        SalesmanId = 3,
                        Name = "The Stones Project Y",
                        TotalAmount = 1000000.0M,
                        Description = "Description",
                        Stage = Deal.DealStage.Offer
                    },
                    new Deal
                    {
                        Id = 4,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        CompanyId = 4,
                        ContactId = 5,
                        SalesmanId = 3,
                        Name = "Mills & Johnes Rebranding Project",
                        TotalAmount = 10000.0M,
                        Description = "Description",
                        Stage = Deal.DealStage.Negotiation
                    },
                    new Deal
                    {
                        Id = 5,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        CompanyId = 2,
                        ContactId = 2,
                        SalesmanId = 3,
                        Name = "Newman Project2",
                        TotalAmount = 1000000.0M,
                        Description = "Description",
                        Stage = Deal.DealStage.Negotiation
                    },
                    new Deal
                    {
                        Id = 6,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        CompanyId = 2,
                        ContactId = 2,
                        SalesmanId = 1,
                        Name = "Newman Project3",
                        TotalAmount = 1000000.0M,
                        Description = "Description",
                        Stage = Deal.DealStage.Won
                    },
                    new Deal
                    {
                        Id = 7,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        CompanyId = 2,
                        ContactId = 2,
                        SalesmanId = 1,
                        Name = "Newman Project4",
                        TotalAmount = 1000000.0M,
                        Description = "Description",
                        Stage = Deal.DealStage.Invoiced
                    },
                    new Deal
                    {
                        Id = 8,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        CompanyId = 2,
                        ContactId = 2,
                        SalesmanId = 1,
                        Name = "Newman Project5",
                        TotalAmount = 1000000.0M,
                        Description = "Description",
                        Stage = Deal.DealStage.Closed,
                        ClosingDate = new DateTime(2021, 1, 1, 8, 30, 0)
                    }
                );
        }
    }
}
