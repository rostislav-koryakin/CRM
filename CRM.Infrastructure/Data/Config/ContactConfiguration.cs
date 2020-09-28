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
                .HasOne(c => c.Company)
                .WithMany(c => c.Contacts)
                .HasForeignKey(c => c.CompanyId)
                .OnDelete(DeleteBehavior.Restrict);

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
                        Email = "emma.stone@stones.com",
                        Phone = "32131221311"
                    },
                    new Contact
                    {
                        Id = 2,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        CompanyId = 2,
                        FirstName = "John",
                        LastName = "Newman",
                        Email = "john@newman.com",
                        Phone = "123123123"
                    },
                    new Contact
                    {
                        Id = 3,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        CompanyId = 2,
                        FirstName = "Adam",
                        LastName = "Newman",
                        Email = "adam@newman.com",
                        Phone = "423123123"
                    },
                    new Contact
                    {
                        Id = 4,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        CompanyId = 3,
                        FirstName = "Michel",
                        LastName = "Mech",
                        Email = "michel@tech-mech.com",
                        Phone = "34525234"
                    },
                    new Contact
                    {
                        Id = 5,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        CompanyId = 4,
                        FirstName = "Abel",
                        LastName = "Mills",
                        Email = "abel@mills-johnes.com",
                        Phone = "76432342"
                    },
                    new Contact
                    {
                        Id = 6,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        CompanyId = 4,
                        FirstName = "Kate",
                        LastName = "Johnes",
                        Email = "kate@mills-johnes.com",
                        Phone = "76432341"
                    }
                );
        }
    }
}
