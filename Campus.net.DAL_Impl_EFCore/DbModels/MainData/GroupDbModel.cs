using Campus.net.DAL_Impl_EFCore.DbModels.RelationClasses;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.DbModels.MainData
{
    internal class GroupDbModel
    {
        public Guid Id { get; private set; }
        public string GroupName { get; private set; }
        public Guid SpecializationDbModelId { get; private set; }
        public List<StudentDbModel> StudentDbModels { get; private set; }
        public List<TeacherSubject_GroupDbModel> TeacherSubject_GroupDbModels { get; private set; }

        public GroupDbModel(Guid id, string groupName, Guid specializationDbModelId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(groupName, 5, 5);
            CustomValidator.ValidateId(specializationDbModelId);
            Id = id;
            GroupName = groupName;
            SpecializationDbModelId = specializationDbModelId;
            StudentDbModels = new List<StudentDbModel>();
            TeacherSubject_GroupDbModels = new List<TeacherSubject_GroupDbModel>();
        }
        public void IncludeTS_GDbList(List<TeacherSubject_GroupDbModel> TS_GDbModels)
        {
            CustomValidator.ValidateObject(TS_GDbModels);
            TeacherSubject_GroupDbModels = TS_GDbModels;
        }
    }
}
