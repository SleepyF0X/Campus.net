using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.Mappers
{
    internal interface IMapper<TEntity, TModel>
    {
        public TModel EntityToModel(TEntity item);
        public TEntity EntityToModel(TModel item);
    }
}
