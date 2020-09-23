using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;

namespace CRM.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<BaseEntity> BaseEntities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<DealProduct> DealProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Salesman> Salesmen { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<Salesman>()
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

            modelBuilder.Entity<Company>()
                .HasData(
                    new Company
                    {
                        Id = 1,
                        TaxpayerNumber = "9173848217",
                        Name = "The Stones",
                        City = "Portland",
                        Street = "35",
                        ZipCode = "3121"
                    },
                    new Company
                    {
                        Id = 2,
                        TaxpayerNumber = "34539292923",
                        Name = "Newman Corp.",
                        City = "New York",
                        Street = "5",
                        ZipCode = "23232"
                    }
                );

            modelBuilder.Entity<Contact>()
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

            modelBuilder.Entity<Activity>()
                .HasData(
                    new Activity
                    {
                        Id = 1,
                        ContactId = 1,
                        SalesmanId = 1,
                        Name = "Onboarding meeting",
                        StartDate = new DateTime(2020, 7, 16, 13, 30, 0),
                        EndDate = new DateTime(2020, 7, 16, 14, 30, 0),
                        Description = "Description . . .",
                        Type = Activity.ActivityType.Meeting
                    },
                    new Activity
                    {
                        Id = 2,
                        ContactId = 1,
                        SalesmanId = 2,
                        Name = "Negotiation Call",
                        StartDate = new DateTime(2020, 7, 23, 7, 30, 0),
                        EndDate = new DateTime(2020, 7, 23, 8, 30, 0),
                        Description = "Description . . .",
                        Type = Activity.ActivityType.Call
                    },
                    new Activity
                    {
                        Id = 3,
                        ContactId = 2,
                        SalesmanId = 3,
                        Name = "Onboarding call",
                        StartDate = new DateTime(2020, 7, 24, 11, 0, 0),
                        EndDate = new DateTime(2020, 7, 24, 13, 0, 0),
                        Description = "Description . . .",
                        Type = Activity.ActivityType.Call
                    },
                    new Activity
                    {
                        Id = 4,
                        ContactId = 3,
                        SalesmanId = 4,
                        Name = "Negotiation meeting",
                        StartDate = new DateTime(2020, 7, 25, 13, 30, 0),
                        EndDate = new DateTime(2020, 7, 25, 15, 30, 0),
                        Description = "Description . . .",
                        Type = Activity.ActivityType.Meeting
                    }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product
                    {
                        Id = 1,
                        Name = "Digital Marketing",
                        Price = 10000.0M
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Branding",
                        Price = 20000.0M
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Content Creation",
                        Price = 30000.0M
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Strategic Planning",
                        Price = 40000.0M
                    }
                );

            modelBuilder.Entity<Deal>()
                .HasData(
                    new Deal
                    {
                        Id = 1,
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
                        CompanyId = 1,
                        ContactId = 1,
                        SalesmanId = 2,
                        Name = "The Stones Project X",
                        TotalAmount = 929301.0M,
                        Description = "Description",
                        Stage = Deal.DealStage.Ongoing
                    },
                    new Deal
                    {
                        Id = 3,
                        CompanyId = 1,
                        ContactId = 1,
                        SalesmanId = 4,
                        Name = "The Stones Project Y",
                        TotalAmount = 20039499.0M,
                        Description = "Description",
                        Stage = Deal.DealStage.New
                    }
                );

            modelBuilder.Entity<DealProduct>()
                .HasData(
                    new DealProduct
                    {
                        DealId = 1,
                        ProductId = 1
                    },
                    new DealProduct
                    {
                        DealId = 1,
                        ProductId = 2
                    },
                    new DealProduct
                    {
                        DealId = 1,
                        ProductId = 3,

                    },
                    new DealProduct
                    {
                        DealId = 1,
                        ProductId = 4
                    },
                    new DealProduct
                    {
                        DealId = 2,
                        ProductId = 1
                    },
                    new DealProduct
                    {
                        DealId = 3,
                        ProductId = 2
                    },
                    new DealProduct
                    {
                        DealId = 3,
                        ProductId = 1
                    }
                );
        }

        public override int SaveChanges()
        {
            SetBaseProperties();
            return base.SaveChanges();
        }

        public void SetBaseProperties()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is BaseEntity
                    && (e.State == EntityState.Added
                    || e.State == EntityState.Modified));

            foreach (var entityEntry in entries)
            {
                ((BaseEntity)entityEntry.Entity).UpdatedDate = DateTime.Now;

                if (entityEntry.State == EntityState.Added)
                {
                    ((BaseEntity)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }

        }
    }
}
