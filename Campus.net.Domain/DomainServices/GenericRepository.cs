using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.DomainServices
{
    public interface IGenericRepository<TEntity>
    {
        TEntity GetById(Guid id);
        IReadOnlyCollection<TEntity> GetAll();
        bool Add(TEntity entity);
        bool Delete(Guid id);
        bool UpdateById(Guid id);
        bool UpdateByEntity(TEntity entity);
    }
}
