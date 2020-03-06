using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.DbModels.RelationClasses
{
    internal class TeacherSubjectDbModel
    {
        public Guid Id { get; private set; }
        public Guid TeacherDbModelId { get; private set; }
        public Guid SubjectDbModelId { get; private set; }

        public TeacherSubjectDbModel(Guid id, Guid teacherDbModelId, Guid subjectDbModelId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateId(teacherDbModelId);
            CustomValidator.ValidateId(subjectDbModelId);
            Id = Id;
            TeacherDbModelId = teacherDbModelId;
            SubjectDbModelId = subjectDbModelId;
        }
    }
}
