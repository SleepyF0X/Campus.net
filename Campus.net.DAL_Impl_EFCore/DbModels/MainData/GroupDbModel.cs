using Campus.net.DAL_Impl_EFCore.RelationClasses;
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
        public Guid SpecializationId { get; private set; }
        public List<StudentDbModel> Students { get; private set; }
        public List<TeacherSubject_GroupDbModel> TeacherSubject_GroupDbModels { get; private set; }

        public GroupDbModel(Guid id, string groupName, Guid specializationId, List<StudentDbModel> students)
        {
            Id = id;
            GroupName = groupName;
            SpecializationId = specializationId;
            Students = students;
            TeacherSubject_GroupDbModels = new List<TeacherSubject_GroupDbModel>();
        }
        public void IncludeTS_GDbList(List<TeacherSubject_GroupDbModel> TS_GDbModels)
        {
            CustomValidator.ValidateObject(TS_GDbModels);
            TeacherSubject_GroupDbModels = TS_GDbModels;
        }
    }
}
