using CRM.Web.Models.Interfaces;
using System;

namespace CRM.Web.Models.Entities
{
    public abstract class BaseEntity : ICreatedAndUpdatedDate
    {
        public int Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
