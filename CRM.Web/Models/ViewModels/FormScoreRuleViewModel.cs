using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Web.Models.ViewModels
{
    public class FormScoreRuleViewModel
    {
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public enum RuleCriteria
        {
            Industry,
            Size,
            Country
        }

        [Required]
        public RuleCriteria Criteria { get; set; }

        public enum ScoreRelationSymbol
        {
            Equals,
            IsLess,
            IsGreater
        }

        [Required]
        [Display(Name = "Relation Symbol")]
        public ScoreRelationSymbol RelationSymbol { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 2)]
        public string Value { get; set; }

        [Required]
        [Range(-50, 50)]
        public int Points { get; set; }
    }
}
