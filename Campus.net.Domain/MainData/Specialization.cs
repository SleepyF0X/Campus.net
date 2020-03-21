using Campus.net.Domain.AdditionalData;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Campus.net.Domain.MainData
{
    public sealed class Specialization
    {
        public Guid Id { get; }
        public string Name { get; }
        public Guid SpecialtyId { get; }
        public Guid DepartmentId { get; }
        private readonly List<Group> _groups;
        private readonly List<SubjectData> _subjectDatas;
        public IReadOnlyCollection<Group> Groups => _groups.AsReadOnly();
        public IReadOnlyCollection<SubjectData> SubjectDatas => _subjectDatas.AsReadOnly();

        public Specialization(Guid id, string name, Guid specialtyId, Guid departmentId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 100);
            CustomValidator.ValidateId(specialtyId);
            CustomValidator.ValidateId(departmentId);
            Id = id;
            Name = name;
            SpecialtyId = specialtyId;
            DepartmentId = departmentId;
            _groups = new List<Group>();
            _subjectDatas = new List<SubjectData>();
        }

        public Specialization(List<Group> groups, List<SubjectData> subjectDatas, Guid id, string name,
            Guid specialtyId, Guid departmentId) : this(id, name, specialtyId, departmentId)
        {
            CustomValidator.ValidateObject(groups);
            CustomValidator.ValidateObject(subjectDatas);
            _groups = groups;
            _subjectDatas = subjectDatas;
        }
    }
}