using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Campus.net.Domain.MainData
{
    public class Faculty
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        private List<Department> _departments;
        public IReadOnlyCollection<Department> Departments
        {
            get
            {
                return _departments.AsReadOnly();
            }
            private set
            {
                _departments = value.ToList();
            }
        }

        public Faculty(Guid id, string name)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 100);
            Id = id;
            Name = name;
            _departments = new List<Department>();
        }
    }
}