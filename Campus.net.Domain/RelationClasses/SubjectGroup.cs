using Campus.net.Domain.MainData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.RelationClasses
{
    public class SubjectGroup
    {
        public Subject Subject { get; }
        public Group Group { get; }

        public SubjectGroup(Subject subject, Group group)
        {
            Subject = subject;
            Group = group;
        }
    }
}
