using CRM.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CRM.Infrastructure.Data
{
    class EfRepository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly AppDbContext _dbContext;
        private DbSet<T> _entities;
        
        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _entities = _dbContext.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T GetById(int id)
        {
            return _entities.SingleOrDefault(e => e.Id == id);
        }

        public void Add(T entity)
        {
            _entities.Add(entity);
            SaveChanges();

        }
        public void Update(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            SaveChanges();

        }
        public void Delete(T entity)
        {
            _entities.Remove(entity);
            SaveChanges();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
