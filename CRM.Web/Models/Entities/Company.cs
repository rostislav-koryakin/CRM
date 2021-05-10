using System.Collections.Generic;

namespace CRM.Web.Models.Entities
{
    public class Company : BaseEntity
    {
        public string TaxpayerNumber {get; set;}

        public string Name { get; set; }

        public string Website { get; set; }

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

        public string Country { get; set; }

        public string City { get; set; }
        
        public string Street { get; set; }

        public string ZipCode { get; set; }

        public int? Score { get; set; }

        public virtual List<Contact> Contacts { get; set; }

        public virtual List<Deal> Deals { get; set; }
    }
}
