using System;
using System.Collections.Generic;
using System.Text;
using Campus.net.DAL_Impl_EFCore.DbModels.AdditionalData;
using Campus.net.Domain.AdditionalData;
using Campus.net.Shared;

namespace Campus.net.DAL_Impl_EFCore.Mappers
{
    internal sealed class TeacherExpDataMapper : IMapper<TeacherExpData, TeacherExpDataDbModel>
    {
        public TeacherExpDataDbModel EntityToModel(TeacherExpData item)
        {
            CustomValidator.ValidateObject(item);
            return new TeacherExpDataDbModel(item.Id, item.Rating, item.Position, item.Experience);
        }

        public TeacherExpData ModelToEntity(TeacherExpDataDbModel item)
        {
            CustomValidator.ValidateObject(item);
            return new TeacherExpData(item.Id, item.Raiting, item.Position, item.Expirience);
        }
    }
}
