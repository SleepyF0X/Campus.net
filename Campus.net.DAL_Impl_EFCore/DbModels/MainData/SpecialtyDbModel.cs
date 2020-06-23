using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.DbModels.MainData
{
    internal sealed class SpecialtyDbModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Number { get; private set; }
        public List<SpecializationDbModel> SpecializationDbModels { get; private set; }

        public SpecialtyDbModel(Guid id, string name, int number)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 100);
            CustomValidator.ValidateNumber(number, 1, 200);
            Id = id;
            Name = name;
            Number = number;
            SpecializationDbModels = new List<SpecializationDbModel>();
        }
    }
}
