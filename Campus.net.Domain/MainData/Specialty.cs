using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Campus.net.Domain.MainData
{
    public class Specialty
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Number { get; private set; }
        public Guid FacultyId { get; private set; }
        public Faculty Faculty { get; private set; }

        private List<Specialization> _specializations;
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

        public Specialty(Guid id, string name, int number, List<Specialization> specializations, Faculty faculty)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 80);
            CustomValidator.ValidateNumber(number, 1, 200);
            CustomValidator.ValidateObject(specializations);
            CustomValidator.ValidateObject(faculty);
            Id = id;
            Name = name;
            Number = number;
            Faculty = faculty;
            _specializations = specializations;
        }
    }
}