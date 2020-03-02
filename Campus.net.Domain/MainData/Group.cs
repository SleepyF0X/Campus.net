using Campus.net.Domain.AdditionalData;
using Campus.net.Domain.RelationClasses;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Campus.net.Domain.MainData
{
    public class Group
    {
        public Guid Id { get; private set; }
        public string GroupName { get; private set; }
        public Specialization Specialization { get; private set; }
        private List<Student> _students;
        public IReadOnlyCollection<Student> Students
        {
            get
            {
                return _students.AsReadOnly();
            }
            private set
            {
                _students = value.ToList();
            }
        }
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
        public IReadOnlyCollection<TeacherSubject> TeacherSubjects => (from tsg in _teacherSubjectGroups where tsg.Teacher.Id.Equals(Id) select new TeacherSubject(tsg.Teacher, tsg.Subject)).ToList().AsReadOnly();

        public Group(Guid id, string groupName, Specialization specialization)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(groupName, 5, 5);
            CustomValidator.ValidateObject(specialization);
            Id = id;
            GroupName = groupName;
            Specialization = specialization;
            _students = new List<Student>();
            _teacherSubjectGroups = new List<TeacherSubjectGroup>();
        }
    }
}