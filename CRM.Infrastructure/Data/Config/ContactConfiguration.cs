using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Data.Config
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasKey(c => c.Id);

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
                        CompanyId = 1,
                        FirstName = "Emma",
                        LastName = "Stone",
                        Email = "emma.stone@stones.com",
                        Phone = "32131221311"
                    },
                    new Contact
                    {
                        Id = 2,
                        CompanyId = 2,
                        FirstName = "John",
                        LastName = "Newman",
                        Email = "john@newman.com",
                        Phone = "123123123"
                    },
                    new Contact
                    {
                        Id = 3,
                        CompanyId = 2,
                        FirstName = "Adam",
                        LastName = "Newman",
                        Email = "adam@newman.com",
                        Phone = "423123123"
                    }
                );
        }
    }
}
