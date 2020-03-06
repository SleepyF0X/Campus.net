using Campus.net.Domain.MainData;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.RelationClasses
{
    public class SubjectGroup
    {
        public Subject Subject { get; private set; }
        public Group Group { get; private set; }

        public SubjectGroup(Subject subject, Group group)
        {
            CustomValidator.ValidateObject(subject);
            CustomValidator.ValidateObject(group);
            Subject = subject;
            Group = group;
        }
    }
}
