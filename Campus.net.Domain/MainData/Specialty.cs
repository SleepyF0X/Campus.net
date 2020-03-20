using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Campus.net.Domain.MainData
{
    public sealed class Specialty
    {
        public Guid Id { get; }
        public string Name { get; }
        public int Number { get; }
        private readonly List<Specialization> _specializations;
        public IReadOnlyCollection<Specialization> Specializations => _specializations.AsReadOnly();

        public Specialty(Guid id, string name, int number)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 80);
            CustomValidator.ValidateNumber(number, 1, 200);
            Id = id;
            Name = name;
            Number = number;
            _specializations = new List<Specialization>();
        }

        public Specialty(List<Specialization> specializations, Guid id, string name, int number) : this(id, name,
            number)
        {
            CustomValidator.ValidateObject(specializations);
            _specializations = specializations;
        }
    }
}