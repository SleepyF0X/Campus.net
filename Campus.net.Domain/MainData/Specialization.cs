using Campus.net.Domain.AdditionalData;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Campus.net.Domain.MainData
{
    public class Specialization
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Specialty Specialty { get; private set; }
        public Department Department { get; private set; }
        private List<Group> _groups;
        private List<SubjectData> _subjectDatas;
        public IReadOnlyCollection<Group> Groups
        {
            get
            {
                return _groups.AsReadOnly();
            }
            private set
            {
                _groups = value.ToList();
            }
        }
        public IReadOnlyCollection<SubjectData> SubjectDatas
        {
            get
            {
                return _subjectDatas.AsReadOnly();
            }
            private set
            {
                _subjectDatas = value.ToList();
            }
        }

        public Specialization(Guid id, string name, Specialty specialty, Department department)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 100);
            CustomValidator.ValidateObject(specialty);
            CustomValidator.ValidateObject(department);
            Id = id;
            Name = name;
            Specialty = specialty;
            Department = department;
            _groups = new List<Group>();
        }
    }
}