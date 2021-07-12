using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OwnerAPI.Contracts;

namespace OwnerAPI.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext context;
        private readonly DbSet<T> table;

        protected RepositoryBase(RepositoryContext context)
        {
            this.context = context;
            table = this.context.Set<T>();
        }

        public void Create(T entiy)
        {
            table.Add(entiy);
        }

        public void Delete(T entity)
        {
            table.Remove(entity);
        }

        public IQueryable<T> FindAll()
        {
            return table.AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return table.Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            table.Update(entity);
        }
    }
}