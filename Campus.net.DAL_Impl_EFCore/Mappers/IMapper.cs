using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.Mappers
{
    internal interface IMapper<TDomainModel, TDbModel>
    {
        public TDbModel DomainToDb(TDomainModel item);
        public TDomainModel DbToDomain(TDbModel item);
    }
}
