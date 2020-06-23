using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.DbModels.MainData
{
    internal sealed class DepartmentDbModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public Guid FacultyDbModelId { get; private set; }
        public List<SpecializationDbModel> SpecializationDbModels { get; private set; }
        public List<TeacherDbModel> TeacherDbModels { get; private set; }

        public DepartmentDbModel(Guid id, string name, Guid facultyDbModelId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 100);
            CustomValidator.ValidateId(facultyDbModelId);
            Id = id;
            Name = name;
            FacultyDbModelId = facultyDbModelId;
            SpecializationDbModels = new List<SpecializationDbModel>();
            TeacherDbModels = new List<TeacherDbModel>();
        }
    }
}
