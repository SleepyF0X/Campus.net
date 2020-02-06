using Campus.net.Shared;
using System;
using System.Collections.Generic;

namespace Campus.net.Domain.MainData
{
    public class Specialty
    {
        public Guid Id { get; }
        public string Name { get; }
        public int Number { get; } //126 121 123...

        //private readonly List<Department> _departments;
        //public IReadOnlyCollection<Department> Departments => _departments.AsReadOnly();
        private readonly List<Faculty> _faculties;

        private readonly List<Specialization> _specializations;
        public IReadOnlyCollection<Faculty> Faculties => _faculties.AsReadOnly();
        public IReadOnlyCollection<Specialization> Specializations => _specializations.AsReadOnly();

        public Specialty(Guid id, string name, int number, List<Faculty> faculties)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 80);
            CustomValidator.ValidateNumber(number, 1, 200);
            //CustomValidator.ValidateObject(departments);
            CustomValidator.ValidateObject(faculties);
            Id = id;
            Name = name;
            Number = number;
            //_departments = departments;
            _faculties = faculties;
        }
    }
}