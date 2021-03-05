using CRM.Core.Entities;
using System.Threading.Tasks;

namespace CRM.Web.Services
{
    public interface ISalesmenService
    {
        public Task<PaginatedList<Salesman>> GetSalesmen(string sortOrder, string searchString, string currentFilter, int? pageNumber);

        public Task<Salesman> GetSalesmanlById(int? id);

        public Task<bool> CreateSalesman(Salesman salesman);

        public Task<bool> UpdateSalesman(Salesman salesman);

        public Task<bool> DeleteSalesman(int? id);

        public Task<bool> SalesmanExists(int id);
    }
}
