using CRM.Web.Models.Entities;
using System.Threading.Tasks;

namespace CRM.Web.Services
{
    public interface IDealProductsService : IBaseService<DealProduct>
    {
        public Task<bool> SumTotalAmountOnDeal(int? dealId);
    }
}
