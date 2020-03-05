using Campus.net.Domain.AdditionalData;
using Campus.net.Shared;
using Campus.net.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;


namespace Campus.net.Domain.MainData
{
    public class Group
    {
        public Guid Id { get; }
        private readonly List<Student> _students;
        private readonly Dictionary<Subject, Teacher> _subjectTeacher;
        public IReadOnlyCollection<Student> Students => _students.AsReadOnly();
        public IReadOnlyDictionary<Subject, Teacher> SubjectTeacher => new ReadOnlyDictionary<Subject, Teacher>(_subjectTeacher);
        public GroupName GroupName { get; }
        public Guid SpecializationId { get; }
        public Specialization Specialization { get { return SpecializationToGroups.Specializations[SpecializationId]; } }

        public Group(Guid id, List<Student> students, Dictionary<Subject, Teacher> subjectTeacher, GroupName groupName)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateObject(students);
            CustomValidator.ValidateObject(subjectTeacher);
            CustomValidator.ValidateObject(groupName);
            Id = id;
            _students = students;
            _subjectTeacher = subjectTeacher;
            GroupName = groupName;
        }
    }
}