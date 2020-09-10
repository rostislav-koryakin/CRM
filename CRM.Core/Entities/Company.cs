using System.Collections.Generic;

namespace CRM.Core.Entities
{
    public class Company : BaseEntity
    {
        public int Id { get; set; }

        public int TaxpayerNumber {get; set;}

        public string Name { get; set; }

        public string City { get; set; }
        
        public string Street { get; set; }

        public string ZipCode { get; set; }

        public virtual List<Contact> Contacts { get; set; }

        public virtual List<Deal> Deals { get; set; }
    }
}
