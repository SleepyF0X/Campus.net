using Campus.net.Domain.MainData;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.RelationClasses
{
    public sealed class TeacherSubject
    {
        public Guid TeacherId { get; }
        public Guid SubjectId { get; }

        public TeacherSubject(Guid teacherId, Guid subjectId)
        {
            CustomValidator.ValidateId(teacherId);
            CustomValidator.ValidateId(subjectId);
            TeacherId = teacherId;
            SubjectId = subjectId;
        }
    }
}