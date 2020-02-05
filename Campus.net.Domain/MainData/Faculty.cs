using System;
using System.Collections.Generic;
using System.Text;
using Campus.net.Domain.AdditionalData;
using Campus.net.Shared;

namespace Campus.net.Domain.MainData
{
    public class Faculty
    {
        public Guid Id { get; } 
        public FacultyContactData FacultyContactData { get; } //можно расширять
        public FacultyInfoData FacultyInfoData { get; } 
        private readonly List<Department> _departments;
        private readonly List<Specialty> _specialties;
        public IReadOnlyCollection<Department> Departments => _departments.AsReadOnly();
        public IReadOnlyCollection<Specialty> Specialties => _specialties.AsReadOnly();

        public Faculty(Guid id, string name, string dean, FacultyContactData facultyContactData, FacultyInfoData facultyInfoData, List<Department> departments, List<Specialty> specialties)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateObject(facultyContactData);
            CustomValidator.ValidateObject(facultyInfoData);
            CustomValidator.ValidateObject(departments);
            CustomValidator.ValidateObject(specialties);
            Id = id;
            FacultyInfoData = facultyInfoData;
            FacultyContactData = facultyContactData;
            _departments = departments;
            _specialties = specialties;
        }
    }
}
