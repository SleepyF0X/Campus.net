using Campus.net.Domain.MainData;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.RelationClasses
{
    public sealed class TeacherSubjectGroup
    {
        public Guid Id { get; }
        public Guid TeacherId { get; }
        public Guid SubjectId { get; }
        public Guid GroupId { get; }

        public TeacherSubjectGroup(Guid id, Guid teacherId, Guid subjectId, Guid groupId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateId(teacherId);
            CustomValidator.ValidateId(subjectId);
            CustomValidator.ValidateId(groupId);
            Id = id;
            TeacherId = teacherId;
            SubjectId = subjectId;
            GroupId = groupId;
        }
    }
}