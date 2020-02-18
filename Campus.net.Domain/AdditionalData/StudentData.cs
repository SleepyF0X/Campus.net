using Campus.net.Domain.Enums;
using Campus.net.Domain.MainData;
using Campus.net.Shared;
using System;

namespace Campus.net.Domain.AdditionalData
{
    public class StudentData
    {
        public Guid Id { get; }
        public Faculty Faculty => Specialization.Specialty.Faculty;
        public Specialty Specialty => Specialization.Specialty;
        public Department Department => Specialization.Department;
        public Specialization Specialization { get; }
        public int Course { get; }
        public DateTimeOffset EntryDate { get; }
        public StudyForm StudyForm { get; }
        public StudyType StudyType { get; }

        public StudentData(Guid id, Specialization specialization, DateTimeOffset entryDate, StudyForm studyForm, StudyType studyType)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateObject(specialization);
            Id = id;
            Specialization = specialization;
            EntryDate = entryDate;
            StudyForm = studyForm;
            StudyType = studyType;
        }
    }
}