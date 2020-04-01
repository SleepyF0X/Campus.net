using Campus.net.Domain.MainData;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.RelationClasses
{
    public sealed class TeacherGroup
    {
        public Guid TeacherId { get; }
        public Guid GroupId { get; }

        public TeacherGroup(Guid teacherId, Guid groupId)
        {
            CustomValidator.ValidateId(teacherId);
            CustomValidator.ValidateId(groupId);
            TeacherId = teacherId;
            GroupId = groupId;
        }
    }
}