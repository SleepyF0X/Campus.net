using System;
using System.Collections.Generic;
using System.Text;
using Campus.net.Shared;

namespace Campus.net.Domain.MainData
{
    public class Specialty
    {
        public Guid Id { get; }
        public string Name { get; }
        public int Number { get; } //126 121 123...
        private readonly List<Department> _departments;
        private readonly List<Faculty> _faculties;
        public IReadOnlyCollection<Department> Departments => _departments.AsReadOnly();
        public IReadOnlyCollection<Faculty> Faculties => _faculties.AsReadOnly();

        public Specialty(Guid id, string name, int number, List<Department> departments, List<Faculty> faculties)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 80);
            CustomValidator.ValidateNumber(number, 1, 200);
            CustomValidator.ValidateObject(departments);
            CustomValidator.ValidateObject(faculties);
            Id = id;
            Name = name;
            Number = number;
            _departments = departments;
            _faculties = faculties;
        }
    }
}
