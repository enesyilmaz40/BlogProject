using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core.Repository
{
    public interface IRepository<T> where T :class
    {
        ValueTask<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        //Task<T> Get(Expression<Func<T, bool>> filter);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindQuery(Expression<Func<T, bool>> predicate);

        Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);



    }
}
