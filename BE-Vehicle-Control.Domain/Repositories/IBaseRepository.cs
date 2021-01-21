using System;
using System.Collections.Generic;

namespace BE_Vehicle_Control.Domain.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
         IEnumerable<TEntity> GetAll();
         TEntity GetById(Guid id);
         void Add(TEntity entity);
         void Update(TEntity entity);
          void Remove(TEntity entity);
    }
}