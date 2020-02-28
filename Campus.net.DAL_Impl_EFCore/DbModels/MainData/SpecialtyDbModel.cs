using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.DbModels.MainData
{
    internal class SpecialtyDbModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public int Number { get; private set; }
        public Guid FacultyId { get; private set; }
        public List<SpecializationDbModel> SpecializationDbModels { get; private set; }

        public SpecialtyDbModel(Guid id, string name, int number, Guid facultyId)
        {
            Id = id;
            Name = name;
            Number = number;
            FacultyId = facultyId;
            SpecializationDbModels = new List<SpecializationDbModel>();
        }
    }
}
