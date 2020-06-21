using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.Mappers
{
    internal interface IMapper<TDomain, TDbModel>
    {
        public TDbModel DomainToDb(TDomain item);
        public TDomain DbToDomain(TDbModel item);
    }
}
