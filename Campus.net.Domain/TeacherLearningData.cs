using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Campus.net.Domain
{
    public class TeacherLearningData
    {
        public Guid Id { get; }
        private List<Group> _groups;
        private List<Subject> _subjects;
        public IReadOnlyCollection<Group> Groups => _groups.AsReadOnly();
        public IReadOnlyCollection<Subject> Subjects => _subjects.AsReadOnly();
    }
}
