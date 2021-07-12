using System;
using System.Linq;
using System.Linq.Expressions;

namespace OwnerAPI.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        void Create(T entiy);
        void Update(T entity);
        void Delete(T entity);
    }
}