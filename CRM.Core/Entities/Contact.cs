using System.Collections.Generic;

namespace CRM.Core.Entities
{
    public class Contact : BaseEntity
    {

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual Company Company { get; set; }

        public virtual int CompanyId { get; set; }

        public virtual List<Deal> Deals { get; set; }

        public virtual List<Activity> Activities { get; set; }
    }
}
