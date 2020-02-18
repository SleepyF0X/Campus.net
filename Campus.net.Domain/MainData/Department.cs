using Campus.net.Shared;
using System;
using System.Collections.Generic;

namespace Campus.net.Domain.MainData
{
    public class Department
    {
        public Guid Id { get; }
        public string Name { get; }
        private readonly List<Specialization> _specializations;
        private readonly List<Teacher> _teachers;
        public IReadOnlyCollection<Specialization> Specializations => _specializations.AsReadOnly();
        public IReadOnlyCollection<Teacher> Teachers => _teachers.AsReadOnly();

        public Department(Guid id, string name, List<Specialization> specializations, List<Teacher> teachers, List<Group> groups)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 100);
            CustomValidator.ValidateObject(specializations);
            CustomValidator.ValidateObject(teachers);
            CustomValidator.ValidateObject(groups);
            Id = id;
            Name = name;
            _specializations = specializations;
            _teachers = teachers;
        }
    }
}