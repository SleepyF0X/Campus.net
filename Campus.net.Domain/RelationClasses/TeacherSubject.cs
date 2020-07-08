using Campus.net.Domain.MainData;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.RelationClasses
{
    public sealed class TeacherSubject
    {
        public Guid Id { get; }
        public Guid TeacherId { get; }
        public Guid SubjectId { get; }

        public TeacherSubject(Guid id, Guid teacherId, Guid subjectId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateId(teacherId);
            CustomValidator.ValidateId(subjectId);
            Id = id;
            TeacherId = teacherId;
            SubjectId = subjectId;
        }
    }
}