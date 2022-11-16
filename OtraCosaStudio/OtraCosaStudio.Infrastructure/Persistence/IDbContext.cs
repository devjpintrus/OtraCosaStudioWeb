using OtraCosaStudio.Model;
using System;
using System.Data.Entity;

namespace OtraCosaStudio.Infrastructure.Persistence
{
    public interface IDbContext
    {
        IDbSet<TEntity> Set<TEntity>() where TEntity : EntityBase;

        int SaveChanges();
    }
}
