using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Core;
using Data.Domain;

namespace Data
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IDbContext _context;
        private IDbSet<T> _entities;

        public Repository(IDbContext context)
        {
            this._context = context;
        }

        protected virtual IDbSet<T> Entities => _entities ?? (_entities = _context.Set<T>());

        public virtual IQueryable<T> Table => this.Entities;

        public virtual void Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            this.Entities.Add(entity);
            this._context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            this._context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            this.Entities.Add(entity);
            this._context.SaveChanges();
        }

        public virtual IQueryable<T> FindBy(Expression<Func<T,bool>> predicate)
        {
            return this.Entities.Where(predicate);
        }
    }
   
}