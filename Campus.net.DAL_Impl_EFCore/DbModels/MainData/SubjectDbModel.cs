using Campus.net.DAL_Impl_EFCore.DbModels.AdditionalData;
using Campus.net.DAL_Impl_EFCore.DbModels.RelationClasses;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.DbModels.MainData
{
    internal sealed class SubjectDbModel
    {
        public Guid Id { get; private set; }
        public string SubjectName { get; private set; }
        public List<TeacherSubject_GroupDbModel> TeacherSubject_GroupDbModels { get; private set; }
        public List<SubjectDataDbModel> SubjectDataDbModels { get; private set; }

        public SubjectDbModel(Guid id, string subjectName)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(subjectName, 2, 60);
            Id = id;
            SubjectName = subjectName;
            TeacherSubject_GroupDbModels = new List<TeacherSubject_GroupDbModel>();
            SubjectDataDbModels = new List<SubjectDataDbModel>();
        }
    }
}
