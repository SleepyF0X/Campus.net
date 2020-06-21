using Campus.net.DAL_Impl_EFCore.Data.ContextFolder;
using Campus.net.DAL_Impl_EFCore.DbModels.AdditionalData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.AdditionalData;
using Campus.net.Domain.AdditionalData;

namespace Campus.net.DAL_Impl_EFCore.Mappers.Implementation.AdditionalData
{
    internal sealed class SubjectDataMapper : ISubjectDataMapper
    {
        private readonly CampusDbContext _context;

        public SubjectDataMapper(CampusDbContext context)
        {
            _context = context;
        }

        public SubjectDataDbModel ModelToEntity(SubjectData item)
        {
            return new SubjectDataDbModel();
        }

        public SubjectData EntityToModel(SubjectDataDbModel item)
        {
            return new SubjectData();
        }
    }
}
