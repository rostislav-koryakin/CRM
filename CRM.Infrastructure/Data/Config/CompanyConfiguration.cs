using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CRM.Infrastructure.Data.Config
{
    public class CompanyConfiguration : BaseEntityConfiguration<Company>
    {
        public override void Configure(EntityTypeBuilder<Company> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder
                .Property(c => c.TaxpayerNumber)
                .IsRequired()
                .HasColumnType("varchar(15)");

            entityTypeBuilder
                .Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(127)");

            entityTypeBuilder
                .Property(c => c.Website)
                .HasColumnType("varchar(127)");

            entityTypeBuilder
                .Property(c => c.NoOfEmployees);

            entityTypeBuilder
                .Property(c => c.Industry)
                .HasConversion<string>();

            entityTypeBuilder
                .Property(c => c.Country)
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
                .Property(c => c.Score)
                .HasDefaultValue(0);

            entityTypeBuilder
                .HasIndex(c => c.TaxpayerNumber)
                .IsUnique();

            entityTypeBuilder
                .HasData(
                    new Company
                    {
                        Id = 1,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        TaxpayerNumber = "9173848217",
                        Name = "The Stones",
                        City = "Portland",
                        Street = "35",
                        ZipCode = "3121"
                    },
                    new Company
                    {
                        Id = 2,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        TaxpayerNumber = "34539292923",
                        Name = "Newman Corp.",
                        City = "New York",
                        Street = "5",
                        ZipCode = "23232"
                    },
                    new Company
                    {
                        Id = 3,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        TaxpayerNumber = "34534545345",
                        Name = "Tech-Mech Inc.",
                        City = "Denver",
                        Street = "12",
                        ZipCode = "54211"
                    },
                    new Company
                    {
                        Id = 4,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        TaxpayerNumber = "9876983453",
                        Name = "Mills & Johnes",
                        City = "New Heaven",
                        Street = "91",
                        ZipCode = "30100"
                    }
                );
        }
    }
}
