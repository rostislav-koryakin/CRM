using System.Collections.Generic;
using CRM.Core.Entities;

namespace CRM.Web.ViewModels
{
    public class CompanyViewModel
    {
        public Company Company { get; set; }

        public IEnumerable<Contact> Contacts { get; set; }

        public IEnumerable<Deal> Deals { get; set; }
    }
}
