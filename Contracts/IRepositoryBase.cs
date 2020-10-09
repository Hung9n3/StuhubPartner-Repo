using Entities.Models;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        Task<List<T>> FindAll();
        Task<T> FindByIdAsync(int id, CancellationToken cancellationToken = default);
        void Create(T entities);
        void Delete(T entity);
        void Update(T entity);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
