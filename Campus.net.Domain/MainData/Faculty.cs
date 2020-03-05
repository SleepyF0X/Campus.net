using Campus.net.Shared;
using Campus.net.Domain.Relations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Campus.net.Domain.MainData
{
    public class Faculty
    {
        public Guid Id { get; }
        public string Name { get; }
        private readonly List<Department> _departments;

        public IReadOnlyCollection<Department> Specializations
        {
            get
            {
                foreach (var department in FacultyToDepartments.Departments.Values)
                {
                    if (department.Id.Equals(Id)) _departments.Add(department);
                }
                return new ReadOnlyCollection<Department>(_departments);
            }
        }

        public Faculty(Guid id, string name)
        {
            CustomValidator.ValidateId(id);
            Id = id;
            _departments = new List<Department>();
        }
    }
}