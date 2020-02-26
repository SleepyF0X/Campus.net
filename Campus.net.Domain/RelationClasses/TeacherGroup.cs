using Campus.net.Domain.MainData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.RelationClasses
{
    public class TeacherGroup
    {
        public Teacher Teacher { get; }
        public Group Group { get; }

        public TeacherGroup(Teacher teacher, Group group)
        {
            Teacher = teacher;
            Group = group;
        }
    }
}
