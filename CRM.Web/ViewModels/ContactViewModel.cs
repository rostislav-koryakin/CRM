using CRM.Core.Entities;
using System.Collections.Generic;

namespace CRM.Web.ViewModels
{
    public class ContactViewModel
    {
        public Contact Contact { get; set; }

        public IEnumerable<Activity> Activities { get; set; }
    }
}
