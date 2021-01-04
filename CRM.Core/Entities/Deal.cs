using System;
using System.Collections.Generic;

namespace CRM.Core.Entities
{
    public class Deal : BaseEntity
    {
        public string Name { get; set; }

        public decimal TotalAmount { get; set; }

        public string Description { get; set; }

        public DateTime? ClosingDate { get; set; }

        public enum DealStage
        {
            New,
            Analisis,
            Offer,
            Negotiation,
            Won,
            Lost,
            Invoiced,
            Closed
        }

        public DealStage Stage { get; set; }

        public virtual Contact Contact { get; set; }

        public virtual int ContactId { get; set; }

        public virtual Company Company { get; set; }

        public virtual int CompanyId { get; set; }

        public virtual Salesman Salesman { get; set; }

        public virtual int SalesmanId { get; set; }

        public virtual List<DealProduct> DealsProducts { get; set; }
    }
}
