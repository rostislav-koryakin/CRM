using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CRM.Infrastructure.Data
{
    public class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext;
        
        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbContext.Set<T>()
                .Where(expression)
                .ToListAsync();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity;

        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
