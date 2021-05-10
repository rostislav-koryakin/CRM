using CRM.Web.Models.Entities;
using System.Collections.Generic;

namespace CRM.Web.Models.ViewModels
{
    public class ContactViewModel
    {
        public Contact Contact { get; set; }

        public Company Company { get; set; }

        public IEnumerable<Activity> Activities { get; set; }
    }
}
