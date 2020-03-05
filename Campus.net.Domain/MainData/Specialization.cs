using Campus.net.Shared;
using System;
using System.Collections.Generic;
using Campus.net.Domain.Relations;
using System.Collections.ObjectModel;

namespace Campus.net.Domain.MainData
{
    public class Specialization
    {
        public Guid Id { get; }
        public string Name { get; }
        public Specialty Specialty { get; }
        public Guid DepartmentId { get; }
        public Department Department { get { return DepartmentToSpecializations.Departments[DepartmentId]; } }
        public Guid SpecialityId { get; }
        public Specialty Speciality { get { return SpecialityToSpecializations.Speciality[SpecialityId]; } }
        private readonly List<Group> _groups;
        public IReadOnlyCollection<Group> Groups
        {
            get
            {
                foreach(var group in SpecializationToGroups.Groups.Values)
                {
                    if (group.Id.Equals(Id)) _groups.Add(group);
                }
                return new ReadOnlyCollection<Group>(_groups);
            }
        }

        public Specialization(Guid id, string name)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 100);
            Id = id;
            Name = name;
            _groups = new List<Group>();
        }
    }
}