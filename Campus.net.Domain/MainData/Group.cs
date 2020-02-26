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
        public Guid Id { get; }
        public GroupName GroupName { get; }
        public Specialization Specialization { get; }
        private readonly List<Student> _students;
        public IReadOnlyCollection<Student> Students => _students.AsReadOnly();
        private List<TeacherSubjectGroup> _teacherSubjectGroups;//test
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

        public Group(Guid id, List<Student> students, List<TeacherSubjectGroup> teacherSubjectGroups, GroupName groupName, Specialization specialization)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateObject(students);
            CustomValidator.ValidateObject(teacherSubjectGroups);
            CustomValidator.ValidateObject(groupName);
            CustomValidator.ValidateObject(specialization);
            Id = id;
            _students = students;
            _teacherSubjectGroups = teacherSubjectGroups;
            GroupName = groupName;
            Specialization = specialization;
        }
    }
}