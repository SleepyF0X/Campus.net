using System;
using System.Collections.Generic;

namespace Campus.net.DAL_Impl_EFCore.DbModels.MainData
{
    internal class SpecializationDbModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid SpecialtyId { get; private set; }
        public Guid DepartmentId { get; private set; }
        public List<GroupDbModel> GroupDbModels { get; private set; }

    }
}