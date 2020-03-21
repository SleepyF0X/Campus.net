using Campus.net.Domain.MainData;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.RelationClasses
{
    public sealed class SubjectGroup
    {
        public Subject Subject { get; }
        public Group Group { get; }

        public SubjectGroup(Subject subject, Group group)
        {
            CustomValidator.ValidateObject(subject);
            CustomValidator.ValidateObject(group);
            Subject = subject;
            Group = group;
        }
    }
}