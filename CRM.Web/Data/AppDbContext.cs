using CRM.Web.Models.Entities;
using CRM.Web.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace CRM.Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Activity> Activities { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Deal> Deals { get; set; }
        public DbSet<DealProduct> DealProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Salesman> Salesmen { get; set; }
        public DbSet<ScoreRule> ScoreRules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ActivityConfiguration());
            modelBuilder.ApplyConfiguration(new CompanyConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new DealConfiguration());
            modelBuilder.ApplyConfiguration(new DealProductConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new SalesmanConfiguration());
            modelBuilder.ApplyConfiguration(new ScoreRuleConfiguration());
        }
    }
}
