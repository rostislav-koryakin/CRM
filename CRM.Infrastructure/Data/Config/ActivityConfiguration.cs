using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRM.Infrastructure.Data.Config
{
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> entityTypeBuilder)
        {
            entityTypeBuilder
                .HasKey(a => a.Id);

            entityTypeBuilder
                .Property(a => a.Name)
                .IsRequired()
                .HasColumnType("varchar(127)");

            entityTypeBuilder
                .Property(a => a.Description)
                .HasColumnType("varchar(255)");

            entityTypeBuilder
                .Property(a => a.StartDate)
                .IsRequired();

            entityTypeBuilder
                .Property(a => a.EndDate)
                .IsRequired();

            entityTypeBuilder
                .Property(a => a.Type)
                .HasConversion<string>();

            entityTypeBuilder
                .HasOne(a => a.Contact)
                .WithMany(c => c.Activities)
                .HasForeignKey(a => a.ContactId)
                .OnDelete(DeleteBehavior.Restrict);

            entityTypeBuilder
                .HasOne(a => a.Salesman)
                .WithMany(s => s.Activities)
                .HasForeignKey(a => a.SalesmanId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
