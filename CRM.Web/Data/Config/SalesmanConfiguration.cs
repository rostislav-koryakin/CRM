using CRM.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CRM.Web.Data.Config
{
    public class SalesmanConfiguration : BaseEntityConfiguration<Salesman>
    {
        public override void Configure(EntityTypeBuilder<Salesman> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

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
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        FirstName = "Lee",
                        LastName = "Johnes",
                        Email = "lee.johnes@sales.c",
                        Phone = "500500500"
                    },
                    new Salesman
                    {
                        Id = 2,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        FirstName = "Amanda",
                        LastName = "Rodrigez",
                        Email = "amanda.rodrigez@sales.c",
                        Phone = "100100100"
                    },
                    new Salesman
                    {
                        Id = 3,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        FirstName = "Emanuela",
                        LastName = "Kozminsky",
                        Email = "emanuela.kozminsky@sales.c",
                        Phone = "200200200"
                    },
                    new Salesman
                    {
                        Id = 4,
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        FirstName = "Ivo",
                        LastName = "Willson",
                        Email = "ivo.willson@sales.c",
                        Phone = "300300300"
                    },
                    new Salesman
                    {
                        Id = 5,
                        CreatedDate = new DateTime(2021, 1, 2, 8, 30, 0),
                        FirstName = "Daniel",
                        LastName = "Portman",
                        Email = "daniel.portman@sales.c",
                        Phone = "300200300"
                    },
                    new Salesman
                    {
                        Id = 6,
                        CreatedDate = new DateTime(2021, 1, 2, 8, 30, 0),
                        FirstName = "Anna",
                        LastName = "Petersen",
                        Email = "anna.petersen@sales.c",
                        Phone = "300100300"
                    }
                );
        }
    }
}
