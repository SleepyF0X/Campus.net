using Campus.net.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain
{
    public class StudentLearningData
    {
        public Guid Id { get; }
        public Faculty Faculty { get; }
        public Specialty Specialty { get; }
        public Department Department { get; }
        public int Course { get; }
        public DateTimeOffset EntryDate  { get; }
        public StudyForm StudyForm { get; }
        public StudyType StudyType { get; }
    }
}
