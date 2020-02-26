using Campus.net.Domain.MainData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.RelationClasses
{
    public class TeacherSubjectGroup
    {
        public Guid Id { get; private set; }
        public Teacher Teacher { get; private set; }
        public Subject Subject { get; private set; }
        public Group Group { get; private set; }
    }
}
