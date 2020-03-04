using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.DbModels.MainData
{
    internal class StudentDbModel
    {
        public Guid Id { get; private set; }
        public Guid PersonDataDbModelId { get; private set; }
        public Guid StudentDataDbModelId { get; private set; }
        public Guid GroupDbModelId { get; private set; }

        public StudentDbModel(Guid id, Guid personDataDbModelId, Guid studentDataDbModelId, Guid groupDbModelId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateId(personDataDbModelId);
            CustomValidator.ValidateId(studentDataDbModelId);
            CustomValidator.ValidateId(groupDbModelId);
            Id = id;
            PersonDataDbModelId = personDataDbModelId;
            StudentDataDbModelId = studentDataDbModelId;
            GroupDbModelId = groupDbModelId;
        }
    }
}
