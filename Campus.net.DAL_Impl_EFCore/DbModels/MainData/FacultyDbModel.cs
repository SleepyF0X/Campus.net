using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.DbModels.MainData
{
    internal class FacultyDbModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<DepartmentDbModel> DepartmentDbModels { get; private set; }

        public FacultyDbModel(Guid id, string name)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 60);
            Id = id;
            Name = name;
            DepartmentDbModels = new List<DepartmentDbModel>();
        }
    }
}
