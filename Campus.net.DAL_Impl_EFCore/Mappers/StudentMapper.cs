using System;
using System.Collections.Generic;
using System.Text;
using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using Campus.net.Domain.MainData;

namespace Campus.net.DAL_Impl_EFCore.Mappers
{
    internal sealed class StudentMapper : IMapper<Student, StudentDbModel>
    {
        public StudentDbModel EntityToModel(Student item)
        {
            return null;
        }

        public Student ModelToEntity(StudentDbModel item)
        {
            return null;
        }
    }
}
