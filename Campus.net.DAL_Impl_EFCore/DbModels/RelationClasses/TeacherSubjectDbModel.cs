using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.DbModels.RelationClasses
{
    internal class TeacherSubjectDbModel
    {
        public Guid Id { get; private set; }
        public Guid TeacherId { get; private set; }
        public Guid SubjectId { get; private set; }

        public TeacherSubjectDbModel(Guid id, Guid teacherId, Guid subjectId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateId(teacherId);
            CustomValidator.ValidateId(subjectId);
            Id = Id;
            TeacherId = teacherId;
            SubjectId = subjectId;
        }
    }
}
