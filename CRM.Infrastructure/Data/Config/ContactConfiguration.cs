using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CRM.Infrastructure.Data.Config
{
    public class ContactConfiguration : BaseEntityConfiguration<Contact>
    {
        public override void Configure(EntityTypeBuilder<Contact> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder
               .Property(c => c.FirstName)
               .IsRequired()
               .HasColumnType("varchar(127)");

            entityTypeBuilder
                .Property(c => c.LastName)
                .IsRequired()
                .HasColumnType("varchar(127)");

            entityTypeBuilder
                .Property(c => c.Phone)
                .HasColumnType("varchar(15)");

            entityTypeBuilder
                .Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(127)");

            entityTypeBuilder
                .Property(c => c.Position)
                .HasColumnType("varchar(127)");

            entityTypeBuilder
                .Property(c => c.Description)
                .HasColumnType("varchar(255)");

            entityTypeBuilder
                .Property(c => c.Source)
                .HasConversion<string>();

            entityTypeBuilder
                .HasOne(c => c.Company)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            entityTypeBuilder
                .HasIndex(c => new { c.FirstName, c.LastName });
            
            entityTypeBuilder
                .HasData(
                    new Contact
                    {
                        Id = 1,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        CompanyId = 1,
                        FirstName = "Emma",
                        LastName = "Stone",
                        Email = "emma.stone@stones.c",
                        Phone = "32131221311",
                        Position = "CEO",
                        Source = Contact.Sources.Blog
                    },
                    new Contact
                    {
                        Id = 2,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        CompanyId = 2,
                        FirstName = "John",
                        LastName = "Newman",
                        Email = "john@newman.c",
                        Phone = "123123123",
                        Position = "CTO",
                        Source = Contact.Sources.Blog
                    },
                    new Contact
                    {
                        Id = 3,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        CompanyId = 2,
                        FirstName = "Adam",
                        LastName = "Newman",
                        Email = "adam@newman.c",
                        Phone = "423123123",
                        Position = "Sales Rep",
                        Source = Contact.Sources.Website
                    },
                    new Contact
                    {
                        Id = 4,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        CompanyId = 3,
                        FirstName = "Michel",
                        LastName = "Mech",
                        Email = "michel@tech-mech.c",
                        Phone = "34525234",
                        Position = "Sales Rep",
                        Source = Contact.Sources.Marketing
                    },
                    new Contact
                    {
                        Id = 5,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        CompanyId = 4,
                        FirstName = "Abel",
                        LastName = "Mills",
                        Email = "abel@mills-johnes.c",
                        Phone = "76432342",
                        Position = "Sales Rep",
                        Source = Contact.Sources.Marketing
                    },
                    new Contact
                    {
                        Id = 6,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        CompanyId = 4,
                        FirstName = "Kate",
                        LastName = "Johnes",
                        Email = "kate@mills-johnes.c",
                        Phone = "76432341",
                        Position = "Sales Rep",
                        Source = Contact.Sources.Events,
                        Description = "Desc . . ."
                    },
                    new Contact
                    {
                        Id = 7,
                        CreatedDate = new DateTime(2021, 1, 2, 8, 30, 0),
                        CompanyId = 5,
                        FirstName = "Jane",
                        LastName = "Coyre",
                        Email = "jane@gitcm.c",
                        Phone = "76432347",
                        Position = "Sales Rep",
                        Source = Contact.Sources.Marketing
                    },
                    new Contact
                    {
                        Id = 8,
                        CreatedDate = new DateTime(2021, 1, 2, 8, 30, 0),
                        CompanyId = 6,
                        FirstName = "Georgina",
                        LastName = "Murray",
                        Email = "georgina@prec-clinic.c",
                        Phone = "76432348",
                        Position = "Sales Rep",
                        Source = Contact.Sources.Marketing
                    }
                );
        }
    }
}
