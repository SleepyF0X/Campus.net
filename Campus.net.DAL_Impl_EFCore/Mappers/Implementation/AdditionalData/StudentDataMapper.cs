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
        private readonly CampusDbContext _context;
        private readonly ISpecializationMapper _specializationMapper;

        public StudentDataMapper(CampusDbContext context)
        {
            _context = context;
            _specializationMapper = new SpecializationMapper(context);
        }

        public StudentDataDbModel DomainToDb(StudentData item)
        {
            return new StudentDataDbModel(item.Id, item.FacultyId, item.Specialization.Id, item.EntryDate, item.StudyForm, item.StudyType);
        }

        public StudentData DbToDomain(StudentDataDbModel item)
        {
            var specialization = _context.Specializations.Find(item.SpecializationDbModelId);
            return new StudentData(item.Id, Guid.Empty, _specializationMapper.DbToDomain(specialization), item.EntryDate, item.StudyForm, item.StudyType);
        }
    }
}
