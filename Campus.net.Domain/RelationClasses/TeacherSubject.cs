using Campus.net.Domain.MainData;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.RelationClasses
{
    public class TeacherSubject
    {
        public Teacher Teacher { get; }
        public Subject Subject { get; }

        public TeacherSubject(Teacher teacher, Subject subject)
        {
            CustomValidator.ValidateObject(teacher);
            CustomValidator.ValidateObject(subject);
            Teacher = teacher;
            Subject = subject;
        }
    }
}
