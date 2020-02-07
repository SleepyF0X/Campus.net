using Campus.net.Domain.Enums;
using Campus.net.Domain.MainData;
using Campus.net.Shared;
using System;

namespace Campus.net.Domain.AdditionalData
{
    public class StudentLearningData
    {
        public Guid Id { get; }
        public Faculty Faculty => Specialization.Specialty.Faculty;
        public Specialty Specialty => Specialization.Specialty;
        //public Department Department { get; }
        public Specialization Specialization { get; }
        public int Course { get; }
        public DateTimeOffset EntryDate { get; }
        public StudyForm StudyForm { get; }
        public StudyType StudyType { get; }

        public StudentLearningData(Guid id, Specialization specialization, DateTimeOffset entryDate, StudyForm studyForm, StudyType studyType)
        {
            CustomValidator.ValidateId(id);
            //CustomValidator.ValidateObject(department);
            CustomValidator.ValidateObject(specialization);
            Id = id;
            Specialization = specialization;
            EntryDate = entryDate;
            StudyForm = studyForm;
            StudyType = studyType;
        }
    }
}