using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Web.Models.ViewModels
{
    public class FormCompanyViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 4)]
        [Display(Name = "Tax Number")]
        public string TaxpayerNumber { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 1)]
        [Display(Name = "Company Name")]
        public string Name { get; set; }

        [StringLength(120, MinimumLength = 5)]
        public string Website { get; set; }

        [Range(0,1000000000)]
        [Display(Name = "No Of Employees")]
        public int NoOfEmployees { get; set; }

        public enum Industries
        {
            Agriculture,
            Commerce,
            Construction,
            Education,
            Finance,
            Food,
            Health,
            IT,
            Tourism,
            Mining,
            Transport
        }

        public Industries Industry { get; set; }

        [StringLength(120, MinimumLength = 2)]
        public string Country { get; set; }

        [StringLength(120, MinimumLength = 2)]
        public string City { get; set; }

        [StringLength(120, MinimumLength = 1)]
        public string Street { get; set; }

        [StringLength(15, MinimumLength = 1)]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        public int? Score { get; set; }
    }
}
