using Campus.net.Domain.AdditionalData;
using Campus.net.Domain.AdditionalData.TeacherData;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Campus.net.Domain.MainData
{
    public class Teacher
    {
        public Guid Id { get; }
        public PersonData PersonData { get; }
        public TeacherExpData TeacherExpData { get; }
        private readonly Dictionary<Subject, List<Group>> _subjectGroups;
        public IReadOnlyDictionary<Subject, List<Group>> SubjectGroups => new ReadOnlyDictionary<Subject, List<Group>>(_subjectGroups);
        public Department Department { get; }

        public Teacher(Guid id, PersonData personData, TeacherExpData teacherExpData, Dictionary<Subject, List<Group>> subjectGroups, Department department)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateObject(personData);
            CustomValidator.ValidateObject(teacherExpData);
            CustomValidator.ValidateObject(subjectGroups);
            CustomValidator.ValidateObject(department);
            Id = id;
            PersonData = personData;
            TeacherExpData = teacherExpData;
            _subjectGroups = subjectGroups;
            Department = department;
        }
    }
}