public interface IGenericRepository<T> where T : class
{
  Task<T> Get(int id);
  Task<IEnumerable<T>> GetAll();
  Task<int> Add(T entity);
  Task<int> Delete(int id);
  Task<int> Update(T entity); 
}

public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
{
        protected readonly BookStoreDbContext _context;
        public GenericRepository(BookStoreDbContext context)
        {
            _context = context;
        }

        public async Task<T> Get(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
}