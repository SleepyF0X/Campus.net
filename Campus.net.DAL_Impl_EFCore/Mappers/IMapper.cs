using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.Mappers
{
    internal interface IMapper<TModel, TEntity>
    {
        public TEntity ModelToEntity(TModel item);
        public TModel EntityToModel(TEntity item);
    }
}
