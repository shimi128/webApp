using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Domain;

namespace Data
{
    public class AppDbContext: DbContext,IDbContext
    {
        public AppDbContext():base("umbracoDbDSN")
        {
            
        }

        public IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public DbSet<JsonContents> JsonContentses { set; get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
