using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OwnerAPI.Contracts;

namespace OwnerAPI.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly RepositoryContext context;
        private readonly ILogger<RepositoryBase<T>> logger;
        private readonly DbSet<T> table;

        protected RepositoryBase(RepositoryContext context,
                                ILogger<RepositoryBase<T>> logger)
        {
            this.context = context;
            this.logger = logger;
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
            LogSQL(table.AsNoTracking()
                    .ToQueryString());
            return table.AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            LogSQL(table.Where(expression)
                    .AsNoTracking()
                    .ToQueryString());
            return table.Where(expression)
                    .AsNoTracking();
        }

        public IQueryable<T> FindByConditionWithDetails(Expression<Func<T, bool>> expression, string propName)
        {
            LogSQL(table.Where(expression)
                    .Include(propName)
                    .AsNoTracking()
                    .ToQueryString());
            return table.Where(expression)
                    .Include(propName)
                    .AsNoTracking();
        }

        public void Update(T entity)
        {
            table.Update(entity);
        }

        private void LogSQL(string sql)
        {
            logger.LogInformation(sql);
        }
    }
}