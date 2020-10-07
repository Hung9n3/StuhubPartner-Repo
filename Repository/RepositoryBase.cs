using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        public RepositoryContext repositoryContext { get; set; }
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }
        public void Create(T entity)
        {
            repositoryContext.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            repositoryContext.Set<T>().Remove(entity);
        }

        public async Task<List<T>> FindAll()
        {
            var items = await repositoryContext.Set<T>().AsNoTracking().ToListAsync();
            return items;
        }

        public System.Linq.IQueryable<T> FindByCondition(System.Linq.Expressions.Expression<Func<T, bool>> expression)
        {
            return repositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            repositoryContext.Set<T>().Update(entity);
        }
        public virtual async Task<T> FindByIdAsync(int id)
        {
            var item = await repositoryContext.FindAsync<T>(id);
            return item;
        }
        public Task SaveAsync() => repositoryContext.SaveChangesAsync();
    }
}
