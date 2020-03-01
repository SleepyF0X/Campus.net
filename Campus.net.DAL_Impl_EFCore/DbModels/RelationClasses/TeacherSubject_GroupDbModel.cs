using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.DbModels.RelationClasses
{
    internal class TeacherSubject_GroupDbModel
    {
        public Guid Id { get; private set; }
        public Guid TeacherSubjectDbModelId { get; private set; }
        public Guid GroupId { get; private set; }

        public TeacherSubject_GroupDbModel(Guid id, Guid teacherSubjectDbModelId, Guid groupId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateId(id);
            Id = id;
            TeacherSubjectDbModelId = teacherSubjectDbModelId;
            GroupId = groupId;
        }
    }
}
