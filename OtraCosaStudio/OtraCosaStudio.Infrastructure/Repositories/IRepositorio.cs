using OtraCosaStudio.Model;
using System;
using System.Collections.Generic;
using System.Linq; 

namespace OtraCosaStudio.Infrastructure.Repositories
{
    public partial interface IRepositorio<T>
        where T : EntityBase
    {
        T GetById(object id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IQueryable<T> Table { get; }

        void UpdateBatch(List<T> entities);
        void InsertBatch(T entity);

        void DeleteBatch(T entity);
    }
}
