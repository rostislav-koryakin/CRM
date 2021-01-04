using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CRM.Infrastructure.Data.Config
{
    public class ActivityConfiguration : BaseEntityConfiguration<Activity>
    {
        public override void Configure(EntityTypeBuilder<Activity> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

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
                .OnDelete(DeleteBehavior.Cascade);

            entityTypeBuilder
                .HasOne(a => a.Salesman)
                .WithMany(s => s.Activities)
                .HasForeignKey(a => a.SalesmanId)
                .OnDelete(DeleteBehavior.Cascade);
            
            entityTypeBuilder
                .HasData(
                    new Activity
                    {
                        Id = 1,
                        ContactId = 1,
                        SalesmanId = 1,
                        Name = "Onboarding meeting",
                        StartDate = new DateTime(2020, 10, 16, 13, 30, 0),
                        EndDate = new DateTime(2020, 10, 16, 14, 30, 0),
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        Description = "Description . . .",
                        Type = Activity.ActivityType.Meeting
                    },
                    new Activity
                    {
                        Id = 2,
                        ContactId = 2,
                        SalesmanId = 2,
                        Name = "Negotiation Call",
                        StartDate = new DateTime(2020, 10, 23, 7, 30, 0),
                        EndDate = new DateTime(2020, 10, 23, 8, 30, 0),
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        Description = "Description . . .",
                        Type = Activity.ActivityType.Call
                    },
                    new Activity
                    {
                        Id = 3,
                        ContactId = 3,
                        SalesmanId = 3,
                        Name = "Onboarding call",
                        StartDate = new DateTime(2020, 10, 24, 11, 0, 0),
                        EndDate = new DateTime(2020, 10, 24, 13, 0, 0),
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        Description = "Description . . .",
                        Type = Activity.ActivityType.Call
                    },
                    new Activity
                    {
                        Id = 4,
                        ContactId = 4,
                        SalesmanId = 4,
                        Name = "Negotiation meeting",
                        StartDate = new DateTime(2020, 10, 25, 13, 30, 0),
                        EndDate = new DateTime(2020, 10, 25, 15, 30, 0),
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        Description = "Description . . .",
                        Type = Activity.ActivityType.Meeting
                    },
                    new Activity
                    {
                        Id = 5,
                        ContactId = 5,
                        SalesmanId = 5,
                        Name = "Negotiation meeting",
                        StartDate = new DateTime(2020, 10, 25, 13, 30, 0),
                        EndDate = new DateTime(2020, 10, 25, 15, 30, 0),
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        Description = "Description . . .",
                        Type = Activity.ActivityType.Meeting
                    },
                    new Activity
                    {
                        Id = 6,
                        ContactId = 6,
                        SalesmanId = 6,
                        Name = "Negotiation meeting",
                        StartDate = new DateTime(2020, 10, 25, 13, 30, 0),
                        EndDate = new DateTime(2020, 10, 25, 15, 30, 0),
                        CreatedDate = new DateTime(2020, 9, 16, 8, 30, 0),
                        Description = "Description . . .",
                        Type = Activity.ActivityType.Meeting
                    },
                    new Activity
                    {
                        Id = 7,
                        ContactId = 1,
                        SalesmanId = 1,
                        Name = "Negotiation call",
                        StartDate = new DateTime(2021, 1, 25, 13, 30, 0),
                        EndDate = new DateTime(2021, 1, 25, 15, 30, 0),
                        CreatedDate = new DateTime(2021, 1, 25, 8, 30, 0),
                        Description = "Description . . .",
                        Type = Activity.ActivityType.Call
                    },
                    new Activity
                    {
                        Id = 8,
                        ContactId = 1,
                        SalesmanId = 1,
                        Name = "Proposal call",
                        StartDate = new DateTime(2021, 2, 25, 13, 30, 0),
                        EndDate = new DateTime(2021, 2, 25, 15, 30, 0),
                        CreatedDate = new DateTime(2021, 2, 25, 8, 30, 0),
                        Description = "Description . . .",
                        Type = Activity.ActivityType.Call
                    },
                    new Activity
                    {
                        Id = 9,
                        ContactId = 1,
                        SalesmanId = 1,
                        Name = "Contact",
                        StartDate = new DateTime(2021, 2, 26, 13, 30, 0),
                        EndDate = new DateTime(2021, 2, 26, 15, 30, 0),
                        CreatedDate = new DateTime(2021, 2, 26, 8, 30, 0),
                        Description = "Description . . .",
                        Type = Activity.ActivityType.Call
                    },
                    new Activity
                    {
                        Id = 10,
                        ContactId = 2,
                        SalesmanId = 2,
                        Name = "Contact",
                        StartDate = new DateTime(2021, 2, 26, 13, 30, 0),
                        EndDate = new DateTime(2021, 2, 26, 15, 30, 0),
                        CreatedDate = new DateTime(2021, 2, 26, 8, 30, 0),
                        Description = "Description . . .",
                        Type = Activity.ActivityType.Call
                    }
                );
        }
    }
}
