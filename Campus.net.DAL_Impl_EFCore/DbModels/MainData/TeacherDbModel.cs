using Campus.net.DAL_Impl_EFCore.DbModels.RelationClasses;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.DbModels.MainData
{
    internal class TeacherDbModel
    {
        public Guid Id { get; private set; }
        public Guid PersonDataId { get; private set; }
        public Guid TeacherExpDataId { get; private set; }
        public Guid DepartmentId { get; private set; }
        public List<TeacherSubject_GroupDbModel> TeacherSubject_GroupDbModels { get; private set; }

        public TeacherDbModel(Guid id, Guid personDataId, Guid teacherExpDataId, Guid departmentId, List<TeacherSubject_GroupDbModel> teacherSubject_GroupDbModels)
        {
            Id = id;
            PersonDataId = personDataId;
            TeacherExpDataId = teacherExpDataId;
            DepartmentId = departmentId;
            TeacherSubject_GroupDbModels = new List<TeacherSubject_GroupDbModel>();
        }
        public void IncludeTS_GDbList(List<TeacherSubject_GroupDbModel> TS_GDbModels)
        {
            CustomValidator.ValidateObject(TS_GDbModels);
            TeacherSubject_GroupDbModels = TS_GDbModels;
        }
    }
}
