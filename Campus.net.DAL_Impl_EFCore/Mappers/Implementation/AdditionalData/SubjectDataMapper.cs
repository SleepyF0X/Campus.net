using Campus.net.DAL_Impl_EFCore.Data.ContextFolder;
using Campus.net.DAL_Impl_EFCore.DbModels.AdditionalData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.AdditionalData;
using Campus.net.Domain.AdditionalData;
using Campus.net.Shared;

namespace Campus.net.DAL_Impl_EFCore.Mappers.Implementation.AdditionalData
{
    internal sealed class SubjectDataMapper : ISubjectDataMapper
    {
        private readonly CampusDbContext _context;

        public SubjectDataMapper(CampusDbContext context)
        {
            _context = context;
        }

        public SubjectDataDbModel DomainToDb(SubjectData item)
        {
            CustomValidator.ValidateObject(item);
            return new SubjectDataDbModel();
        }

        public SubjectData DbToDomain(SubjectDataDbModel item)
        {
            CustomValidator.ValidateObject(item);
            return new SubjectData();
        }
    }
}
