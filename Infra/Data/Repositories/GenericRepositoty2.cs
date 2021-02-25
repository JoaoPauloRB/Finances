using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Infra.Data.Repositories
{
    public interface IGenericRepository2<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<EntityEntry<T>> AddAsync(T entity);
        T Get(int id);
        T Add(T entity);
        void Delete(T entity);
        void Update(T entity); 
    }

    public class GenericRepository2<T> : IGenericRepository2<T> where T : class
    {
        protected readonly ApplicationContext _context;
        protected DbSet<T> _dbset;
        public GenericRepository2(ApplicationContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<EntityEntry<T>> AddAsync(T entity)
        {
            return await _dbset.AddAsync(entity);
        }

        public T Get(int id)
        {
            return _dbset.Find(id);
        }

        public T Add(T entity)
        {
            return _dbset.Add(entity).Entity;
        }

        public void Delete(T entity)
        {
            _dbset.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbset.Attach(entity);
        }
  }
}