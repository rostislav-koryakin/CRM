﻿// <auto-generated />
using System;
using CRM.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CRM.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200929185025_001")]
    partial class _001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CRM.Core.Entities.Activity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ContactId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("Created Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(255)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(127)");

                    b.Property<int>("SalesmanId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("Updated Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.HasIndex("SalesmanId");

                    b.ToTable("Activities");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ContactId = 1,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description . . .",
                            EndDate = new DateTime(2020, 10, 16, 14, 30, 0, 0, DateTimeKind.Unspecified),
                            Name = "Onboarding meeting",
                            SalesmanId = 1,
                            StartDate = new DateTime(2020, 10, 16, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            Type = "Meeting"
                        },
                        new
                        {
                            Id = 2,
                            ContactId = 2,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description . . .",
                            EndDate = new DateTime(2020, 10, 23, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Name = "Negotiation Call",
                            SalesmanId = 2,
                            StartDate = new DateTime(2020, 10, 23, 7, 30, 0, 0, DateTimeKind.Unspecified),
                            Type = "Call"
                        },
                        new
                        {
                            Id = 3,
                            ContactId = 3,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description . . .",
                            EndDate = new DateTime(2020, 10, 24, 13, 0, 0, 0, DateTimeKind.Unspecified),
                            Name = "Onboarding call",
                            SalesmanId = 3,
                            StartDate = new DateTime(2020, 10, 24, 11, 0, 0, 0, DateTimeKind.Unspecified),
                            Type = "Call"
                        },
                        new
                        {
                            Id = 4,
                            ContactId = 2,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description . . .",
                            EndDate = new DateTime(2020, 10, 25, 15, 30, 0, 0, DateTimeKind.Unspecified),
                            Name = "Negotiation meeting",
                            SalesmanId = 3,
                            StartDate = new DateTime(2020, 10, 25, 13, 30, 0, 0, DateTimeKind.Unspecified),
                            Type = "Meeting"
                        });
                });

            modelBuilder.Entity("CRM.Core.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasColumnType("varchar(127)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("Created Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(127)");

                    b.Property<string>("Street")
                        .HasColumnType("varchar(127)");

                    b.Property<string>("TaxpayerNumber")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("Updated Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("ZipCode")
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("TaxpayerNumber")
                        .IsUnique();

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            City = "Portland",
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Name = "The Stones",
                            Street = "35",
                            TaxpayerNumber = "9173848217",
                            ZipCode = "3121"
                        },
                        new
                        {
                            Id = 2,
                            City = "New York",
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Name = "Newman Corp.",
                            Street = "5",
                            TaxpayerNumber = "34539292923",
                            ZipCode = "23232"
                        },
                        new
                        {
                            Id = 3,
                            City = "Denver",
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Name = "Tech-Mech Inc.",
                            Street = "12",
                            TaxpayerNumber = "34534545345",
                            ZipCode = "54211"
                        },
                        new
                        {
                            Id = 4,
                            City = "New Heaven",
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Name = "Mills & Johnes",
                            Street = "91",
                            TaxpayerNumber = "9876983453",
                            ZipCode = "30100"
                        });
                });

            modelBuilder.Entity("CRM.Core.Entities.Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("Created Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(127)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(127)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(127)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("Updated Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("FirstName", "LastName");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 1,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Email = "emma.stone@stones.com",
                            FirstName = "Emma",
                            LastName = "Stone",
                            Phone = "32131221311"
                        },
                        new
                        {
                            Id = 2,
                            CompanyId = 2,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Email = "john@newman.com",
                            FirstName = "John",
                            LastName = "Newman",
                            Phone = "123123123"
                        },
                        new
                        {
                            Id = 3,
                            CompanyId = 2,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Email = "adam@newman.com",
                            FirstName = "Adam",
                            LastName = "Newman",
                            Phone = "423123123"
                        },
                        new
                        {
                            Id = 4,
                            CompanyId = 3,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Email = "michel@tech-mech.com",
                            FirstName = "Michel",
                            LastName = "Mech",
                            Phone = "34525234"
                        },
                        new
                        {
                            Id = 5,
                            CompanyId = 4,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Email = "abel@mills-johnes.com",
                            FirstName = "Abel",
                            LastName = "Mills",
                            Phone = "76432342"
                        },
                        new
                        {
                            Id = 6,
                            CompanyId = 4,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Email = "kate@mills-johnes.com",
                            FirstName = "Kate",
                            LastName = "Johnes",
                            Phone = "76432341"
                        });
                });

            modelBuilder.Entity("CRM.Core.Entities.Deal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<int>("ContactId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("Created Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(127)");

                    b.Property<int>("SalesmanId")
                        .HasColumnType("int");

                    b.Property<string>("Stage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("Updated Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("ContactId");

                    b.HasIndex("SalesmanId");

                    b.ToTable("Deals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CompanyId = 2,
                            ContactId = 2,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description",
                            Name = "Newman Project",
                            SalesmanId = 1,
                            Stage = "New",
                            TotalAmount = 1000000.0m
                        },
                        new
                        {
                            Id = 2,
                            CompanyId = 1,
                            ContactId = 1,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description",
                            Name = "The Stones Project X",
                            SalesmanId = 2,
                            Stage = "Ongoing",
                            TotalAmount = 929301.0m
                        },
                        new
                        {
                            Id = 3,
                            CompanyId = 1,
                            ContactId = 1,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description",
                            Name = "The Stones Project Y",
                            SalesmanId = 3,
                            Stage = "New",
                            TotalAmount = 20039499.0m
                        },
                        new
                        {
                            Id = 4,
                            CompanyId = 4,
                            ContactId = 5,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Description = "Description",
                            Name = "Mills & Johnes Rebranding Project",
                            SalesmanId = 3,
                            Stage = "New",
                            TotalAmount = 10000.0m
                        });
                });

            modelBuilder.Entity("CRM.Core.Entities.DealProduct", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("Created Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DealId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("Updated Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DealId");

                    b.HasIndex("ProductId");

                    b.ToTable("DealProducts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DealId = 1,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DealId = 1,
                            ProductId = 2
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DealId = 1,
                            ProductId = 3
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DealId = 1,
                            ProductId = 4
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DealId = 2,
                            ProductId = 2
                        },
                        new
                        {
                            Id = 6,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DealId = 3,
                            ProductId = 3
                        },
                        new
                        {
                            Id = 7,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DealId = 3,
                            ProductId = 4
                        },
                        new
                        {
                            Id = 8,
                            CreatedDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DealId = 4,
                            ProductId = 5
                        });
                });

            modelBuilder.Entity("CRM.Core.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("Created Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(127)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("Updated Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Name = "Digital Marketing",
                            Price = 10000.0m
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Name = "Branding",
                            Price = 20000.0m
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Name = "Content Creation",
                            Price = 30000.0m
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Name = "Strategic Planning",
                            Price = 40000.0m
                        },
                        new
                        {
                            Id = 5,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Name = "Rebranding",
                            Price = 10000.0m
                        });
                });

            modelBuilder.Entity("CRM.Core.Entities.Salesman", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("Created Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(127)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(127)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(127)");

                    b.Property<string>("Phone")
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnName("Updated Date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("FirstName", "LastName");

                    b.ToTable("Salesmen");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Email = "lee.johnes@sales.com",
                            FirstName = "Lee",
                            LastName = "Johnes",
                            Phone = "500500500"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Email = "amanda.rodrigez@sales.com",
                            FirstName = "Amanda",
                            LastName = "Rodrigez",
                            Phone = "100100100"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Email = "emanuela.kozminsky@sales.com",
                            FirstName = "Emanuela",
                            LastName = "Kozminsky",
                            Phone = "200200200"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified),
                            Email = "ivo.willson@sales.com",
                            FirstName = "Ivo",
                            LastName = "Willson",
                            Phone = "300300300"
                        });
                });

            modelBuilder.Entity("CRM.Core.Entities.Activity", b =>
                {
                    b.HasOne("CRM.Core.Entities.Contact", "Contact")
                        .WithMany("Activities")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CRM.Core.Entities.Salesman", "Salesman")
                        .WithMany("Activities")
                        .HasForeignKey("SalesmanId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CRM.Core.Entities.Contact", b =>
                {
                    b.HasOne("CRM.Core.Entities.Company", "Company")
                        .WithMany("Contacts")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CRM.Core.Entities.Deal", b =>
                {
                    b.HasOne("CRM.Core.Entities.Company", "Company")
                        .WithMany("Deals")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CRM.Core.Entities.Contact", "Contact")
                        .WithMany("Deals")
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CRM.Core.Entities.Salesman", "Salesman")
                        .WithMany("Deals")
                        .HasForeignKey("SalesmanId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });

            modelBuilder.Entity("CRM.Core.Entities.DealProduct", b =>
                {
                    b.HasOne("CRM.Core.Entities.Deal", "Deal")
                        .WithMany("DealsProducts")
                        .HasForeignKey("DealId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CRM.Core.Entities.Product", "Product")
                        .WithMany("DealsProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}