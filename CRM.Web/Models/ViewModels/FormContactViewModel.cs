using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Web.Models.ViewModels
{
    public class FormContactViewModel
    {
        public int Id { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

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

        [StringLength(120)]
        public string Position { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public enum Sources
        {
            Blog,
            Calls,
            Social_Media,
            Marketing,
            Events,
            Referrals,
            Website
        }

        public Sources Source { get; set; }

        [Display(Name = "Company")]
        public  int CompanyId { get; set; }

    }
}
