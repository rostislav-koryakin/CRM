using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

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
            
            entityTypeBuilder
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
        }
    }
}
