using Campus.net.Shared;
using Campus.net.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Campus.net.Domain.MainData
{
    public class Department
    {
        public Guid Id { get; }
        public string Name { get; }
        private readonly List<Specialization> _specializations;
        private readonly List<Teacher> _teachers;
        public IReadOnlyCollection<Specialization> Specializations
        {
            get
            {
                foreach (var specialization in DepartmentToSpecializations.Specializations.Values)
                {
                    if (specialization.Id.Equals(Id)) _specializations.Add(specialization);
                }
                return new ReadOnlyCollection<Specialization>(_specializations);
            }
        }
        public IReadOnlyCollection<Teacher> Teachers => _teachers.AsReadOnly();

        public Department(Guid id, string name, List<Teacher> teachers, List<Group> groups)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 100);
            CustomValidator.ValidateObject(teachers);
            CustomValidator.ValidateObject(groups);
            Id = id;
            Name = name;
            _specializations = new List<Specialization>();
            _teachers = teachers;
        }
    }
}