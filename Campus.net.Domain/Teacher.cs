using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain
{
    public class Teacher
    {
        public Guid Id { get; }
        public PersonalInfo PersonalInfo { get; }
        public TeacherLearningData TeacherLearningData { get; }
        public double Raiting { get; }
    }
}
