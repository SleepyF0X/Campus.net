using Campus.net.Domain.AdditionalData;
using Campus.net.Domain.RelationClasses;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Campus.net.Domain.MainData
{
    public class Teacher
    {
        public Guid Id { get; private set; }
        public PersonData PersonData { get; private set; }
        public TeacherExpData TeacherExpData { get; private set; }
        public Department Department { get; private set; }
        private List<TeacherSubjectGroup> _teacherSubjectGroups;
        public IReadOnlyCollection<TeacherSubjectGroup> TeacherSubjectGroups
        {
            get
            {
                return _teacherSubjectGroups.AsReadOnly();
            }
            private set
            {
                _teacherSubjectGroups = value.ToList();
            }
        }
        public IReadOnlyCollection<SubjectGroup> SubjectGroups => (from tsg in _teacherSubjectGroups where tsg.Teacher.Id.Equals(Id) select new SubjectGroup(tsg.Subject, tsg.Group)).ToList().AsReadOnly();

        public Teacher(Guid id, PersonData personData, TeacherExpData teacherExpData, Department department)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateObject(personData);
            CustomValidator.ValidateObject(teacherExpData);
            CustomValidator.ValidateObject(department);
            Id = id;
            PersonData = personData;
            TeacherExpData = teacherExpData;
            Department = department;
            _teacherSubjectGroups = new List<TeacherSubjectGroup>();
        }
    }
}