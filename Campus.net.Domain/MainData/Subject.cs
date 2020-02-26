using Campus.net.Domain.AdditionalData;
using Campus.net.Domain.RelationClasses;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Campus.net.Domain.MainData
{
    public class Subject
    {
        public Guid Id { get; }
        public SubjectData SubjectData { get; }
        public string SubjectName { get; }
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
        public IReadOnlyCollection<TeacherGroup> TeacherGroups => (from tsg in _teacherSubjectGroups where tsg.Teacher.Id.Equals(Id) select new TeacherGroup(tsg.Teacher, tsg.Group)).ToList().AsReadOnly();

        public Subject(Guid id, SubjectData subjectData, List<TeacherSubjectGroup> teacherSubjectGroups, string subjectName)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(subjectName, 2, 100);
            CustomValidator.ValidateObject(teacherSubjectGroups);
            Id = id;
            SubjectData = subjectData;
            _teacherSubjectGroups = teacherSubjectGroups;
            SubjectName = subjectName;
        }
    }
}