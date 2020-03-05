using Campus.net.DAL_Impl_EFCore.DbModels.AdditionalData;
using Campus.net.Shared;
using System;
using System.Collections.Generic;

namespace Campus.net.DAL_Impl_EFCore.DbModels.MainData
{
    internal class SpecializationDbModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid SpecialtyDbModelId { get; private set; }
        public Guid DepartmentDbModelId { get; private set; }
        public List<GroupDbModel> GroupDbModels { get; private set; }
        public List<SubjectDataDbModel> SubjectDataDbModels { get; private set; }

        public SpecializationDbModel(Guid id, string name, Guid specialtyDbModelId, Guid departmentDbModelId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 100);
            CustomValidator.ValidateId(specialtyDbModelId);
            CustomValidator.ValidateId(departmentDbModelId);
            Id = id;
            Name = name;
            SpecialtyDbModelId = specialtyDbModelId;
            DepartmentDbModelId = departmentDbModelId;
            GroupDbModels = new List<GroupDbModel>();
            SubjectDataDbModels = new List<SubjectDataDbModel>();
        }
    }
}