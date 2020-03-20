using Campus.net.Domain.MainData;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.RelationClasses
{
    public sealed class TeacherGroup
    {
        public Teacher Teacher { get; }
        public Group Group { get; }

        public TeacherGroup(Teacher teacher, Group group)
        {
            CustomValidator.ValidateObject(teacher);
            CustomValidator.ValidateObject(group);
            Teacher = teacher;
            Group = group;
        }
    }
}