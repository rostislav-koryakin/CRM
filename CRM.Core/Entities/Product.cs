using System.Collections.Generic;

namespace CRM.Core.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public virtual List<DealProduct> DealsProducts { get; set; }
    }
}
