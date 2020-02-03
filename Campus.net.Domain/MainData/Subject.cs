using Campus.net.Domain.AdditionalData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.MainData
{
    public class Subject
    {
        public Guid Id { get; }
        public SubjectInfo SubjectInfo { get; }
        private readonly List<Group> _groups;
        public IReadOnlyCollection<Group> Groups => _groups.AsReadOnly();
        public string SubjectName { get; }
        public Teacher Teacher { get; }
    }
}
