using Campus.net.Domain.MainData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.RelationClasses
{
    public class TeacherSubjectGroup
    {
        public Guid Id { get; }
        public Teacher Teacher { get; }
        public Subject Subject { get; }
        public Group Group { get; }
    }
}
