using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryBase<T> where T : class
    {
        Task<List<T>> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T,bool>> expression);
        void Create(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<T> FindByIdAsync(int id);
        Task SaveAsync();

    }
}
