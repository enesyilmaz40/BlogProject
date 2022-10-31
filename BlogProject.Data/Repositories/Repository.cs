using BlogProject.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Data.Repositories
{
   public class Repository<T> :IRepository<T> where T :class
    {
        protected readonly DbContext Context;

        protected Repository(DbContext context)
        {
            Context = context;
        }

        public async Task AddAsync(T entity)
        {
            await Context.Set<T>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await Context.Set<T>().AddRangeAsync(entities);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Where(predicate);
        }

        public  IQueryable<T> FindQuery(Expression<Func<T, bool>> predicate)
        {
            return  Context.Set<T>().Where(predicate);
        }

     

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await Context.Set<T>().ToListAsync();
        }

        public ValueTask<T> GetByIdAsync(int id)
        {
            return Context.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            Context.Set<T>().Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            Context.Set<T>().RemoveRange(entities);
        }

        public  Task<T> SingleOrDefaultAsync(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().SingleOrDefaultAsync(predicate);
        }

        public void Update(T entity)
        {
            Context.Set<T>().Attach(entity);
            Context.Entry(entity).State = EntityState.Modified;
        }
    }
}
