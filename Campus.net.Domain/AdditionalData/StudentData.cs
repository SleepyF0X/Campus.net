using Campus.net.Domain.Enums;
using Campus.net.Domain.MainData;
using Campus.net.Shared;
using System;

namespace Campus.net.Domain.AdditionalData
{
    public class StudentData
    {
        public Guid Id { get; private set; }
        public Faculty Faculty => Specialization.Department.Faculty;
        public Specialty Specialty => Specialization.Specialty;
        public Department Department => Specialization.Department;
        public Specialization Specialization { get; private set; }
        public int Course
        {
            get
            {
                if (DateTimeOffset.Now.Month >= 8)
                {
                    return DateTimeOffset.Now.Year - EntryDate.Year+1;
                }
                else
                {
                    return DateTimeOffset.Now.Year - EntryDate.Year;
                }
            }
        }
        public DateTimeOffset EntryDate { get; private set; }
        public StudyForm StudyForm { get; private set; }
        public StudyType StudyType { get; private set; }

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