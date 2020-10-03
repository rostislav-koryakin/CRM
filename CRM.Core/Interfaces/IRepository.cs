using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRM.Core.Entities
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task <List<T>> GetAllAsync();
        Task <List<T>> GetByConditionAsync(Expression<Func<T, bool>> expression);
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
