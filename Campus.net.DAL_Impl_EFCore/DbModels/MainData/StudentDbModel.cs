using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.DbModels.MainData
{
    internal class StudentDbModel
    {
        public Guid Id { get; private set; }
        public Guid PersonDataId { get; private set; }
        public Guid StudentDataId { get; private set; }
        public Guid GroupId { get; private set; }

        public StudentDbModel(Guid id, Guid personDataId, Guid studentDataId, Guid groupId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateId(personDataId);
            CustomValidator.ValidateId(studentDataId);
            CustomValidator.ValidateId(groupId);
            Id = id;
            PersonDataId = personDataId;
            StudentDataId = studentDataId;
            GroupId = groupId;
        }
    }
}
