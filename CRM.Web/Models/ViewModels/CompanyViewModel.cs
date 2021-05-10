using CRM.Web.Models.Entities;
using System.Collections.Generic;

namespace CRM.Web.Models.ViewModels
{
    public class CompanyViewModel
    {
        public Company Company { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }

        public IEnumerable<Deal> Deals { get; set; }
    }
}
