using Campus.net.Domain.AdditionalData;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Campus.net.Domain.MainData
{
    public class Subject
    {
        public Guid Id { get; }
        public SubjectData SubjectData { get; }
        private readonly Dictionary<Teacher, List<Group>> _teacherGroups;
        public IReadOnlyDictionary<Teacher, List<Group>> TeacherGroups => new ReadOnlyDictionary<Teacher, List<Group>>(_teacherGroups);
        public string SubjectName { get; }

        public Subject(Guid id, SubjectData subjectData, Dictionary<Teacher, List<Group>> teacherGroups, string subjectName)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(subjectName, 2, 100);
            CustomValidator.ValidateObject(teacherGroups);
            Id = id;
            SubjectData = subjectData;
            _teacherGroups = teacherGroups;
            SubjectName = subjectName;
        }
    }
}