using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Campus.net.Domain.MainData
{
    public class Department
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Faculty Faculty { get; private set; }
        private List<Specialization> _specializations;
        private List<Teacher> _teachers;
        public IReadOnlyCollection<Specialization> Specializations
        {
            get
            {
                return _specializations.AsReadOnly();
            }
            private set
            {
                _specializations = value.ToList();
            }
        }
        public IReadOnlyCollection<Teacher> Teachers
        {
            get
            {
                return _teachers.AsReadOnly();
            }
            private set
            {
                _teachers = value.ToList();
            }
        }

        public Department(Guid id, string name, Faculty faculty)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 100);
            CustomValidator.ValidateObject(faculty);
            Id = id;
            Name = name;
            Faculty = faculty;
            _specializations = new List<Specialization>();
            _teachers = new List<Teacher>();
        }
    }
}