using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Expressions;

namespace Test.TimeTracker.Server.Data
{
    public interface IRepository<T> where T : class
    {
        
        IQueryable<T> GetQueryable();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void Update(T entity);
        Task DeleteAsync(int id);

    }
}
