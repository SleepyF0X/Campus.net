using Campus.net.Domain.AdditionalData.FacultyData;
using Campus.net.Shared;
using System;
using System.Collections.Generic;

namespace Campus.net.Domain.MainData
{
    public class Faculty
    {
        public Guid Id { get; }
        public FacultyContactData FacultyContactData { get; } //можно расширять
        public FacultyInfoData FacultyInfoData { get; }
        //private readonly List<Department> _departments;
        //public IReadOnlyCollection<Department> Departments => _departments.AsReadOnly();
        private readonly List<Specialty> _specialties;

        public IReadOnlyCollection<Specialty> Specialties => _specialties.AsReadOnly();

        public Faculty(Guid id, FacultyContactData facultyContactData, FacultyInfoData facultyInfoData, List<Specialty> specialties)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateObject(facultyContactData);
            CustomValidator.ValidateObject(facultyInfoData);
            //CustomValidator.ValidateObject(departments);
            CustomValidator.ValidateObject(specialties);
            Id = id;
            FacultyInfoData = facultyInfoData;
            FacultyContactData = facultyContactData;
            //_departments = departments;
            _specialties = specialties;
        }
    }
}