using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Web.Models.ViewModels
{
    public class FormSalesmanViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 2)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 2)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Phone]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(120)]
        public string Email { get; set; }

        [Range(0, double.MaxValue)]
        [Display(Name = "Monthly Sales Goal")]
        public decimal MonthlySalesGoal { get; set; }
    }
}
