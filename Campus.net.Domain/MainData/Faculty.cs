using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Campus.net.Domain.MainData
{
    public sealed class Faculty
    {
        public Guid Id { get; }
        public string Name { get; }
        private readonly List<Department> _departments;
        public IReadOnlyCollection<Department> Departments => _departments.AsReadOnly();

        public Faculty(Guid id, string name)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 100);
            Id = id;
            Name = name;
            _departments = new List<Department>();
        }

        public Faculty(List<Department> departments, Guid id, string name) : this(id, name)
        {
            CustomValidator.ValidateObject(departments);
            _departments = departments;
        }
    }
}