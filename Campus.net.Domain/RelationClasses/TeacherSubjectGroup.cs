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
        public Teacher Teacher { get; }
        public Subject Subject { get; }
        public Group Group { get; }

        public TeacherSubjectGroup(Guid id, Teacher teacher, Subject subject, Group group)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateObject(teacher);
            CustomValidator.ValidateObject(subject);
            CustomValidator.ValidateObject(group);
            Id = id;
            Teacher = teacher;
            Subject = subject;
            Group = group;
        }
    }
}