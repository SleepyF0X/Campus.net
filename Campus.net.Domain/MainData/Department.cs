using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Campus.net.Domain.MainData
{
    public sealed class Department
    {
        public Guid Id { get; }
        public string Name { get; }
        public Guid FacultyId { get; }
        private readonly List<Specialization> _specializations;
        private readonly List<Teacher> _teachers;
        public IReadOnlyCollection<Specialization> Specializations => _specializations.AsReadOnly();
        public IReadOnlyCollection<Teacher> Teachers => _teachers.AsReadOnly();

        public Department(Guid id, string name, Guid facultyId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 100);
            CustomValidator.ValidateId(facultyId);
            Id = id;
            Name = name;
            FacultyId = facultyId;
            _specializations = new List<Specialization>();
            _teachers = new List<Teacher>();
        }

        public Department(List<Specialization> specializations, List<Teacher> teachers, Guid id, string name,
            Guid facultyId) : this(id, name, facultyId)
        {
            CustomValidator.ValidateObject(specializations);
            CustomValidator.ValidateObject(teachers);
            _specializations = specializations;
            _teachers = teachers;
        }
    }
}