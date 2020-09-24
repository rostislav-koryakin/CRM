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

            entityTypeBuilder
                .HasData(
                    new Salesman
                    {
                        Id = 1,
                        FirstName = "Lee",
                        LastName = "Johnes",
                        Email = "lee.johnes@sales.com",
                        Phone = "500500500"
                    },
                    new Salesman
                    {
                        Id = 2,
                        FirstName = "Amanda",
                        LastName = "Rodrigez",
                        Email = "amanda.rodrigez@sales.com",
                        Phone = "100100100"
                    },
                    new Salesman
                    {
                        Id = 3,
                        FirstName = "Emanuela",
                        LastName = "Kozminsky",
                        Email = "emanuela.kozminsky@sales.com",
                        Phone = "200200200"
                    },
                    new Salesman
                    {
                        Id = 4,
                        FirstName = "Ivo",
                        LastName = "Willson",
                        Email = "ivo.willson@sales.com",
                        Phone = "300300300"
                    }
                );
        }
    }
}
