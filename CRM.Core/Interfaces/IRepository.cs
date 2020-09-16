using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM.Core.Entities
{
    public interface IRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        void SetBaseProperties();
        int SaveChanges();
        void SaveChangesAsync();
    }
}
