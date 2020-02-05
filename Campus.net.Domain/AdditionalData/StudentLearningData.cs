using Campus.net.Domain.Enums;
using Campus.net.Domain.MainData;
using System;
using System.Collections.Generic;
using System.Text;
using Campus.net.Shared;

namespace Campus.net.Domain.AdditionalData
{
    public class StudentLearningData
    {
        public Guid Id { get; }
        public Faculty Faculty { get; }
        public Specialty Specialty { get; }
        public Department Department { get; }
        public int Course { get; }
        public DateTimeOffset EntryDate { get; }
        public StudyForm StudyForm { get; }
        public StudyType StudyType { get; }

        public StudentLearningData(Guid id, Faculty faculty, Specialty specialty, Department department, DateTimeOffset entryDate, StudyForm studyForm, StudyType studyType)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateObject(faculty);
            CustomValidator.ValidateObject(specialty);
            CustomValidator.ValidateObject(department);
            Id = id;
            Faculty = faculty;
            Specialty = specialty;
            Department = department;
            EntryDate = entryDate;
            StudyForm = studyForm;
            StudyType = studyType;
        }
    }
}
