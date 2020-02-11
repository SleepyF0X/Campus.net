using Campus.net.Shared;
using System;
using System.Collections.Generic;

namespace Campus.net.Domain.MainData
{
    public class Faculty
    {
        public Guid Id { get; }
        public string Name { get; }
        private readonly List<Specialty> _specialties;

        public IReadOnlyCollection<Specialty> Specialties => _specialties.AsReadOnly();

        public Faculty(Guid id, List<Specialty> specialties)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateObject(specialties);
            Id = id;
            _specialties = specialties;
        }
    }
}