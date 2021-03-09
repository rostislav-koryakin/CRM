using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace CRM.Infrastructure.Data.Config
{
    public class ScoreRuleConfiguration : BaseEntityConfiguration<ScoreRule>
    {
        public override void Configure(EntityTypeBuilder<ScoreRule> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder
                .Property(r => r.Criteria)
                .IsRequired()
                .HasConversion<string>();

            entityTypeBuilder
                .Property(r => r.RelationSymbol)
                .IsRequired()
                .HasConversion<string>();

            entityTypeBuilder
                .Property(r => r.Value)
                .IsRequired();

            entityTypeBuilder
                .Property(r => r.RelationSymbol)
                .IsRequired();

            entityTypeBuilder
                .Property(r => r.Points)
                .IsRequired();

            entityTypeBuilder
                .HasData(
                    new ScoreRule
                    {   
                        Id = 1,
                        Criteria = ScoreRule.RuleCriteria.Industry,
                        RelationSymbol = ScoreRule.ScoreRelationSymbol.Equals,
                        Value = "IT",
                        Points = 10
                    },
                    new ScoreRule
                    {
                        Id = 2,
                        Criteria = ScoreRule.RuleCriteria.Size,
                        RelationSymbol = ScoreRule.ScoreRelationSymbol.IsGreater,
                        Value = "50",
                        Points = 10

                    },
                    new ScoreRule
                    {
                        Id = 3,
                        Criteria = ScoreRule.RuleCriteria.Country,
                        RelationSymbol = ScoreRule.ScoreRelationSymbol.Equals,
                        Value = "USA",
                        Points = 10
                    }
                );
        }
    }
}
