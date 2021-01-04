using System.Collections.Generic;

namespace CRM.Core.Entities
{
    public class Salesman : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual List<Activity> Activities { get; set; }

        public virtual List<Deal> Deals { get; set; }
    }
}
