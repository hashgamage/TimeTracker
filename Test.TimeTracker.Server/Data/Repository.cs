using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Test.TimeTracker.Server.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly WorkbenchContext _context;
        private readonly DbSet<T> _dbSet;
        public Repository(WorkbenchContext context)
        {
           
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public IQueryable<T> GetQueryable()
        {
            return _dbSet.AsNoTracking();
        }
        public async Task<T?> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task AddAsync(T entity) => await _dbSet.AddAsync(entity);
        public void Update(T entity) => _dbSet.Update(entity);
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
            }
        }
    }
}
