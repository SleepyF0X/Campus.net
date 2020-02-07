using Campus.net.Shared;
using System;
using System.Collections.Generic;

namespace Campus.net.Domain.MainData
{
    public class Specialization
    {
        public Guid Id { get; }
        public string Name { get; }
        public Specialty Specialty { get; }
        private List<Group> _groups;
        public IReadOnlyCollection<Group> Groups => _groups.AsReadOnly();

        public Specialization(Guid id, string name, List<Group> groups, Specialty specialty)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 100);
            CustomValidator.ValidateObject(groups);
            CustomValidator.ValidateObject(specialty);
            Id = id;
            Name = name;
            _groups = groups;
            Specialty = specialty;
        }
    }
}