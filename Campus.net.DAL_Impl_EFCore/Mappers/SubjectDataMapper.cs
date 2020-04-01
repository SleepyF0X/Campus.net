using System;
using System.Collections.Generic;
using System.Text;
using Campus.net.DAL_Impl_EFCore.DbModels.AdditionalData;
using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using Campus.net.Domain.AdditionalData;
using Campus.net.Shared;

namespace Campus.net.DAL_Impl_EFCore.Mappers
{
    internal sealed class SubjectDataMapper : IMapper<SubjectData, SubjectDataDbModel>
    {
        private readonly CampusDbContext _context;

        public SubjectDataMapper(CampusDbContext context)
        {
            _context = context;
        }

        public SubjectDataDbModel EntityToModel(SubjectData item)
        {
            CustomValidator.ValidateObject(item);
            return new SubjectDataDbModel();
        }

        public SubjectData ModelToEntity(SubjectDataDbModel item)
        {
            CustomValidator.ValidateObject(item);
            return new SubjectData();
        }
    }
}
