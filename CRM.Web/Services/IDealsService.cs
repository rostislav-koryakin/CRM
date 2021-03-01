using CRM.Core.Entities;
using System.Threading.Tasks;

namespace CRM.Web.Services
{
    public interface IDealsService
    {
        public Task<PaginatedList<Deal>> GetDeals(string sortOrder, string searchString, string currentFilter, int? pageNumber);

        public Task<Deal> GetDealById(int? id);

        public Task<bool> CreateDeal(Deal deal);

        public Task<bool> UpdateDeal(Deal deal);

        public Task<bool> DeleteDeal(int? id);

        public Task<bool> DealExists(int id);
    }
}