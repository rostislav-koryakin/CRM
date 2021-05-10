using CRM.Web.Models.Entities;
using System.Collections.Generic;

namespace CRM.Web.Models.ViewModels
{
    public class DealViewModel
    {
        public Deal Deal { get; set; }

        public Contact Contact { get; set; }
        
        public Company Company { get; set; }

        public Salesman Salesman { get; set; }

        public IEnumerable<DealProduct> DealProducts { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
