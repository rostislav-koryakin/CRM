using System;

namespace CRM.Core.Entities
{
    public class Activity : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }
        
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        
        public enum ActivityType
        {
            Call,
            Meeting,
            Task
        }

        public ActivityType Type { get; set; }

        public virtual Contact Contact { get; set; }

        public virtual int ContactId { get; set; }

        public virtual Salesman Salesman { get; set; }

        public virtual int SalesmanId { get; set; }
    }
}
