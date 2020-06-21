using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.DbModels.RelationClasses
{
    internal sealed class TeacherSubject_GroupDbModel
    {
        public Guid Id { get; private set; }
        public Guid TeacherSubjectDbModelId { get; private set; }
        public Guid GroupDbModelId { get; private set; }

        public TeacherSubject_GroupDbModel(Guid id, Guid teacherSubjectDbModelId, Guid groupDbModelId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateId(teacherSubjectDbModelId);
            CustomValidator.ValidateId(groupDbModelId);
            Id = id;
            TeacherSubjectDbModelId = teacherSubjectDbModelId;
            GroupDbModelId = groupDbModelId;
        }
    }
}
