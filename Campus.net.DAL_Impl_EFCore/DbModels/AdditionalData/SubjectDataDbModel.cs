using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using System;

namespace Campus.net.DAL_Impl_EFCore.DbModels.AdditionalData
{
    internal sealed class SubjectDataDbModel
    {
        public Guid Id { get; private set; }
        public Guid SubjectDbModelId { get; private set; }
        public Guid SpecializationDbModelId { get; private set; }
        //Fuck this shit
        //Часы, кредиты, прочая шняга, позже
    }
}