using CRM.Web.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Web.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        public Task<IEnumerable<T>> GetAll();

        public Task<PaginatedList<T>> GetPaginatedList(string sortOrder, string searchString, string currentFilter, int? pageNumber);

        public Task<T> GetById(int? id);

        public Task<bool> Create(T entity);

        public Task<bool> Update(T entity);

        public Task<bool> Delete(int? id);

        public Task<bool> Exists(int id);
    }
}