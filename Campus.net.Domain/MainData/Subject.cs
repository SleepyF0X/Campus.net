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
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public SubjectData SubjectData { get; private set; }
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

        public Subject(Guid id, string name, SubjectData subjectData)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 100);
            Id = id;
            Name = name;
            SubjectData = subjectData;
            _teacherSubjectGroups = new List<TeacherSubjectGroup>();
        }
    }
}