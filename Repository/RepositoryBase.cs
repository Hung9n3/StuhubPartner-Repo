﻿using Contracts;
using Entities.Models;
using Entities.Models.SmartZoneContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected readonly SmartZoneContext _context;
        protected readonly DbSet<T> _dbSet;
        public RepositoryBase(SmartZoneContext repositoryContext)
        {
            _context = repositoryContext;
            _dbSet = _context.Set<T>();
        }
        public virtual IQueryable<T> FindAll(Expression<Func<T, bool>>? predicate = null)
            => _dbSet.WhereIf(predicate != null, predicate!);
        public virtual async Task<T?> FindByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            var item = await _dbSet.FindAsync(id);
            return item;
        }
        public void Add(T entities)
            => _dbSet.Add(entities);
        public void AddRange(IEnumerable<T> entities)
            => _dbSet.AddRange(entities);
        public void Update(T entity)
            => _dbSet.Update(entity);
        public virtual void Delete(T entity)
            => _dbSet.Remove(entity);
        public Task SaveChangesAsync(CancellationToken cancellationToken = default) 
            => _context.SaveChangesAsync(cancellationToken);
        public Task<IDbContextTransaction> BeginTransactionAsync()
            => _context.Database.BeginTransactionAsync();
    }
}
