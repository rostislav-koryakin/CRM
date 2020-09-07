using System;

namespace CRM.Core.Entities
{
    public class BaseEntity
    {
        public int BaseEntityId { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
