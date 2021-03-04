using CRM.Core.Entities;
using System.Threading.Tasks;

namespace CRM.Web.Services
{
    public interface IProductsService
    {
        public Task<PaginatedList<Product>> GetProducts(string sortOrder, string searchString, string currentFilter, int? pageNumber);

        public Task<Product> GetProductById(int? id);

        public Task<bool> CreateProduct(Product product);

        public Task<bool> UpdateProduct(Product product);

        public Task<bool> DeleteProduct(int? id);

        public Task<bool> ProductExists(int id);
    }
}
