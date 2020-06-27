using System;
using Campus.net.DAL_Impl_EFCore.Data.ContextFolder;
using Campus.net.DAL_Impl_EFCore.DbModels.AdditionalData;
using Campus.net.DAL_Impl_EFCore.Mappers.Implementation.MainData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.AdditionalData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.MainData;
using Campus.net.Domain.AdditionalData;

namespace Campus.net.DAL_Impl_EFCore.Mappers.Implementation.AdditionalData
{
    internal sealed class StudentDataMapper : IStudentDataMapper
    {
        public StudentDataDbModel ModelToEntity(StudentData item)
        {
            return new StudentDataDbModel(item.Id, item.FacultyId, item.EntryDate, item.StudyForm, item.StudyType);
        }

        public StudentData EntityToModel(StudentDataDbModel item)
        {
            return new StudentData(item.Id, Guid.Empty, item.EntryDate, item.StudyForm, item.StudyType);
        }
    }
}
