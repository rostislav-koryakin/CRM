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
                        Website = "www.stones.c",
                        Industry = Company.Industries.IT,
                        Country = "USA",
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
                        Website = "www.newman-corp.c",
                        Industry = Company.Industries.IT,
                        Country = "USA",
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
                        Website = "www.tech-mech.c",
                        Industry = Company.Industries.IT,
                        Country = "USA",
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
                        Website = "www.mills-and-jones.c",
                        Industry = Company.Industries.Finance,
                        Country = "USA",
                        City = "New Heaven",
                        Street = "91",
                        ZipCode = "30100"
                    },
                    new Company
                    {
                        Id = 5,
                        CreatedDate = new DateTime(2021, 1, 1, 8, 30, 0),
                        TaxpayerNumber = "9000003",
                        Name = "GTIcm Corp.",
                        Website = "www.gitcm.c",
                        Industry = Company.Industries.Construction,
                        Country = "USA",
                        City = "Denver",
                        Street = "1",
                        ZipCode = "93100"
                    },
                    new Company
                    {
                        Id = 6,
                        CreatedDate = new DateTime(2021, 1, 2, 8, 30, 0),
                        TaxpayerNumber = "9100003",
                        Name = "PREC Clinic Inc.",
                        Website = "www.prec-clinic.c",
                        Industry = Company.Industries.Health,
                        Country = "Germany",
                        City = "Berlin",
                        Street = "Strauss 12",
                        ZipCode = "01233"
                    },
                    new Company
                    {
                        Id = 7,
                        CreatedDate = new DateTime(2021, 1, 3, 8, 30, 0),
                        TaxpayerNumber = "9200003",
                        Name = "Dent Beauty GmbH",
                        Website = "www.dent-beauty-gmbh.c",
                        Industry = Company.Industries.Health,
                        Country = "Germany",
                        City = "Berlin",
                        Street = "Strauss 14",
                        ZipCode = "01233"
                    }
                );
        }
    }
}
