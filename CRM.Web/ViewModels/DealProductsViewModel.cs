using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore.Query;

namespace CRM.Web.ViewModels
{
    public class DealProductsViewModel
    {
        public Deal Deal { get; set; }

        public IIncludableQueryable<DealProduct, Product> DealProducts { get; set; }
    }
}
