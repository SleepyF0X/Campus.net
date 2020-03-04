using Campus.net.DAL_Impl_EFCore.DbModels.RelationClasses;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.DbModels.MainData
{
    internal class SubjectDbModel
    {
        public Guid Id { get; private set; }
        public Guid SubjectDataDbModelId { get; private set; }
        public string SubjectName { get; private set; }
        public List<TeacherSubject_GroupDbModel> TeacherSubject_GroupDbModels { get; private set; }

        public SubjectDbModel(Guid id, Guid subjectDataDbModelId, string subjectName)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateId(subjectDataDbModelId);
            CustomValidator.ValidateString(subjectName, 2, 60);
            Id = id;
            SubjectDataDbModelId = subjectDataDbModelId;
            SubjectName = subjectName;
            TeacherSubject_GroupDbModels = new List<TeacherSubject_GroupDbModel>();
        }
        public void IncludeTS_GDbList(List<TeacherSubject_GroupDbModel> TS_GDbModels)
        {
            CustomValidator.ValidateObject(TS_GDbModels);
            TeacherSubject_GroupDbModels = TS_GDbModels;
        }
    }
}
