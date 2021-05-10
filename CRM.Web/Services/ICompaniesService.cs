using CRM.Web.Models.Entities;
using System.Threading.Tasks;

namespace CRM.Web.Services
{
    public interface ICompaniesService
    {
        public Task<PaginatedList<Company>> GetCompanies(string sortOrder, string searchString, string currentFilter, int? pageNumber);

        public Task<Company> GetCompanyById(int? id);

        public Task<bool> CreateCompany(Company company);

        public Task<bool> UpdateCompany(Company company);

        public Task<bool> DeleteCompany(int? id);

        public Task<bool> CompanyExists(int id);
    }
}