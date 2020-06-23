using Campus.net.DAL_Impl_EFCore.DbModels.AdditionalData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.AdditionalData;
using Campus.net.Domain.AdditionalData;

namespace Campus.net.DAL_Impl_EFCore.Mappers.Implementation.AdditionalData
{
    internal sealed class TeacherExpDataMapper : ITeacherExpDataMapper
    {
        public TeacherExpDataDbModel ModelToEntity(TeacherExpData item)
        {
            return new TeacherExpDataDbModel(item.Id, item.Rating, item.Position, item.Experience);
        }

        public TeacherExpData EntityToModel(TeacherExpDataDbModel item)
        {
            return new TeacherExpData(item.Id, item.Rating, item.Position, item.Experience);
        }
    }
}
