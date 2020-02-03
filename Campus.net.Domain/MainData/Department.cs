using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.MainData
{
    public class Department
    {
        public Guid Id { get; }
        public string Name { get; }
        private readonly List<Specialty> _specialities;
        private readonly List<Teacher> _teachers;
        private readonly List<Group> _groups;
        public IReadOnlyCollection<Specialty> Specialties => _specialities.AsReadOnly();
        public IReadOnlyCollection<Teacher> Teachers => _teachers.AsReadOnly();
        public IReadOnlyCollection<Group> Groups => _groups.AsReadOnly();
    }
}
