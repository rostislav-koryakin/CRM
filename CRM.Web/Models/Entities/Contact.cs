using System.Collections.Generic;

namespace CRM.Web.Models.Entities
{
    public class Contact : BaseEntity
    { 
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Position { get; set; }

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

        public virtual Company Company { get; set; }

        public virtual int CompanyId { get; set; }

        public virtual List<Deal> Deals { get; set; }

        public virtual List<Activity> Activities { get; set; }
    }
}
