using CRM.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Web.Services
{
    public interface IDealProductsService
    {
        public Task<List<DealProduct>> GetDealsItems();

        public Task<DealProduct> GetDealItemById(int? id);

        public Task<bool> CreateDealItem(DealProduct dealProduct);

        public Task<bool> UpdateDealItem(DealProduct dealProduct);

        public Task<bool> DeleteDealItem(int? id);

        public Task<bool> DealItemExists(int id);

        public Task<bool> SumTotalAmountOnDeal(int? dealId);
    }
}
