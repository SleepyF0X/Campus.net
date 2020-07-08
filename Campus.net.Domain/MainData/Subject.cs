using Campus.net.Domain.AdditionalData;
using Campus.net.Domain.RelationClasses;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Campus.net.Domain.MainData
{
    public sealed class Subject
    {
        public Guid Id { get; }
        public string Name { get; }
        private readonly List<SubjectData> _subjectDatas;
        public IReadOnlyCollection<SubjectData> SubjectDatas => _subjectDatas.AsReadOnly();

        public Subject(Guid id, string name)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 100);
            Id = id;
            Name = name;
            _subjectDatas = new List<SubjectData>();
        }

        public Subject(List<SubjectData> subjectDatas, Guid id,
            string name) : this(id, name)
        {
            CustomValidator.ValidateObject(subjectDatas);
            _subjectDatas = subjectDatas;
        }
    }
}