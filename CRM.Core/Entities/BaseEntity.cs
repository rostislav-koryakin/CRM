using CRM.Core.Interfaces;
using System;

namespace CRM.Core.Entities
{
    public abstract class BaseEntity : ICreatedAndUpdatedDate
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
