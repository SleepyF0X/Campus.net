using Campus.net.Domain.Enums;
using Campus.net.Domain.MainData;
using Campus.net.Shared;
using System;

namespace Campus.net.Domain.AdditionalData
{
    public sealed class StudentData
    {
        public Guid Id { get; }
        public Guid FacultyId { get; }
        public Specialization Specialization { get; }

        public int Course
        {
            get
            {
                if (DateTimeOffset.Now.Month >= 8) return DateTimeOffset.Now.Year - EntryDate.Year + 1;
                return DateTimeOffset.Now.Year - EntryDate.Year;
            }
        }

        public DateTimeOffset EntryDate { get; }
        public StudyForm StudyForm { get; }
        public StudyType StudyType { get; }

        public StudentData(Guid id, Guid facultyId, Specialization specialization, DateTimeOffset entryDate, StudyForm studyForm, StudyType studyType)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateId(facultyId);
            CustomValidator.ValidateObject(specialization);
            Id = id;
            FacultyId = facultyId;
            Specialization = specialization;
            EntryDate = entryDate;
            StudyForm = studyForm;
            StudyType = studyType;
        }
    }
}