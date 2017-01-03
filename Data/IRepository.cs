using System;
using System.Linq;
using System.Linq.Expressions;
using Data.Domain;

namespace Data
{
    public interface IRepository<T> where T: BaseEntity
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
    }
}
