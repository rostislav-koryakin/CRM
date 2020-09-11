using CRM.Core.Interfaces;
using System;

namespace CRM.Core.Entities
{
    public class BaseEntity : ICreatedAndUpdatedDate
    {
        public int BaseEntityId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
