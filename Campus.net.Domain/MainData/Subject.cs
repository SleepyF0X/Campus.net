using Campus.net.Domain.AdditionalData;
using Campus.net.Shared;
using System;
using System.Collections.Generic;

namespace Campus.net.Domain.MainData
{
    public class Subject
    {
        public Guid Id { get; }
        public SubjectData SubjectInfo { get; }
        private readonly List<Group> _groups;
        public IReadOnlyCollection<Group> Groups => _groups.AsReadOnly();
        public string SubjectName { get; }
        public Teacher Teacher { get; }

        public Subject(Guid id, SubjectData subjectInfo, List<Group> groups, string subjectName, Teacher teacher)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(subjectName, 2, 100);
            CustomValidator.ValidateObject(subjectInfo);
            CustomValidator.ValidateObject(groups);
            CustomValidator.ValidateObject(teacher);
            Id = id;
            SubjectInfo = subjectInfo;
            _groups = groups;
            SubjectName = subjectName;
            Teacher = teacher;
        }
    }
}