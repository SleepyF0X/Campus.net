using Campus.net.Domain.MainData;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.RelationClasses
{
    public sealed class SubjectGroup
    {
        public Guid SubjectId { get; }
        public Guid GroupId { get; }

        public SubjectGroup(Guid subjectId, Guid groupId)
        {
            CustomValidator.ValidateId(subjectId);
            CustomValidator.ValidateId(groupId);
            SubjectId = subjectId;
            GroupId = groupId;
        }
    }
}