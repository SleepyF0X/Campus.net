using Campus.net.DAL_Impl_EFCore.DbModels.RelationClasses;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.DbModels.MainData
{
    internal sealed class TeacherDbModel
    {
        public Guid Id { get; private set; }
        public Guid PersonDataDbModelId { get; private set; }
        public Guid TeacherExpDataDbModelId { get; private set; }
        public Guid DepartmentDbModelId { get; private set; }
        public List<TeacherSubject_GroupDbModel> TeacherSubject_GroupDbModels { get; private set; }

        public TeacherDbModel(Guid id, Guid personDataDbModelId, Guid teacherExpDataDbModelId, Guid departmentDbModelId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateId(personDataDbModelId);
            CustomValidator.ValidateId(teacherExpDataDbModelId);
            CustomValidator.ValidateId(departmentDbModelId);
            Id = id;
            PersonDataDbModelId = personDataDbModelId;
            TeacherExpDataDbModelId = teacherExpDataDbModelId;
            DepartmentDbModelId = departmentDbModelId;
            TeacherSubject_GroupDbModels = new List<TeacherSubject_GroupDbModel>();
        }
    }
}
