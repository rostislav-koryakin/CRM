using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Web.Models.ViewModels
{
    public class FormDealViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }

        [StringLength(250, MinimumLength = 2)]
        public string Description { get; set; }

        [Display(Name = "Closing Date")]
        public DateTime? ClosingDate { get; set; }

        public enum DealStage
        {
            New,
            Analisis,
            Offer,
            Negotiation,
            Won,
            Lost,
            Invoiced,
            Closed
        }

        public DealStage Stage { get; set; }

        [Required]
        [Display(Name = "Contact")]
        public  int ContactId { get; set; }

        [Required]
        [Display(Name = "Company")]
        public  int CompanyId { get; set; }

        [Required]
        [Display(Name = "Salesman")]
        public  int SalesmanId { get; set; }
    }
}
