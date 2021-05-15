using System;
using System.ComponentModel.DataAnnotations;

namespace CRM.Web.Models.ViewModels
{
    public class FormProductViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [StringLength(250, MinimumLength = 2)]
        public string Description { get; set; }

        [Required]
        [Range(0, 100)]
        public decimal VAT { get; set; }
    }
}
