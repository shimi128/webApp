using System.Data.Entity;
using Data.Domain;

namespace Data
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
    }
}