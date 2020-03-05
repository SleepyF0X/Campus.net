using Campus.net.Shared;
using Campus.net.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Campus.net.Domain.MainData
{
    public class Specialty
    {
        public Guid Id { get; }
        public string Name { get; }
        public int Number { get; }
        public Faculty Faculty { get; }

        private readonly List<Specialization> _specializations;
        public IReadOnlyCollection<Specialization> Specializations
        {
            get
            {
                foreach (var specialization in SpecialityToSpecializations.Specializations.Values)
                {
                    if (specialization.Id.Equals(Id)) _specializations.Add(specialization);
                }
                return new ReadOnlyCollection<Specialization>(_specializations);
            }
        }

        public Specialty(Guid id, string name, int number, Faculty faculty)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 80);
            CustomValidator.ValidateNumber(number, 1, 200);
            CustomValidator.ValidateObject(faculty);
            Id = id;
            Name = name;
            Number = number;
            Faculty = faculty;
            _specializations = new List<Specialization>();
        }
    }
}