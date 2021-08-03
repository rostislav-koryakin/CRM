using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Web.Models.ViewModels
{
    public class FormActivityViewModel
    {
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(250, MinimumLength = 2)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        public enum ActivityType
        {
            Call,
            Meeting,
            Task
        }

        [Required]
        public ActivityType Type { get; set; }

        [Required]
        [Display(Name = "Contact")]
        public int ContactId { get; set; }

        [Required]
        [Display(Name = "Salesman")]
        public int SalesmanId { get; set; }
    }
}
