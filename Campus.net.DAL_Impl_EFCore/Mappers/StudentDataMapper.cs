using System;
using System.Collections.Generic;
using System.Text;
using Campus.net.DAL_Impl_EFCore.DbModels.AdditionalData;
using Campus.net.Domain.AdditionalData;
using Campus.net.Domain.MainData;
using Campus.net.Shared;

namespace Campus.net.DAL_Impl_EFCore.Mappers
{
    internal sealed class StudentDataMapper : IMapper<StudentData, StudentDataDbModel>
    {
        private readonly CampusDbContext _context;
        private readonly SpecializationMapper _specializationMapper;

        public StudentDataMapper(CampusDbContext context)
        {
            _context = context;
            _specializationMapper = new SpecializationMapper(context);
        }

        public StudentDataDbModel EntityToModel(StudentData item)
        {
            CustomValidator.ValidateObject(item);
            return new StudentDataDbModel(item.Id, item.Specialization.Id, item.EntryDate, item.StudyForm, item.StudyType);
        }

        public StudentData ModelToEntity(StudentDataDbModel item)
        {
            CustomValidator.ValidateObject(item);
            return new StudentData(item.Id, Guid.Empty, _specializationMapper.ModelToEntity(item.SpecializationDbModelId), item.EntryDate, item.StudyForm, item.StudyType);
        }
    }
}
