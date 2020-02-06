using Campus.net.Domain.MainData;
using Campus.net.Shared;
using System;
using System.Collections.Generic;

namespace Campus.net.Domain.AdditionalData
{
    public class TeacherLearningData
    {
        public Guid Id { get; }
        private readonly List<Group> _groups;
        private readonly List<Subject> _subjects;
        public IReadOnlyCollection<Group> Groups => _groups.AsReadOnly();
        public IReadOnlyCollection<Subject> Subjects => _subjects.AsReadOnly();

        public TeacherLearningData(Guid id, List<Group> groups, List<Subject> subjects)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateObject(groups);
            CustomValidator.ValidateObject(subjects);
            Id = id;
            _groups = groups;
            _subjects = subjects;
        }
    }
}