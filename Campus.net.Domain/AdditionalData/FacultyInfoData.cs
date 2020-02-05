using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.AdditionalData
{
    public class FacultyInfoData
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Dean { get; } //вариативно, декан фака
        public string FoundationYear { get; } //год создания, ибо нахер тут дата

        public FacultyInfoData(Guid id, string name, string dean, string foundationYear)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 20);
            CustomValidator.ValidateString(dean, 3, 60);
            Name = name;
            Dean = dean;
            FoundationYear = foundationYear;
        }
    }
}
