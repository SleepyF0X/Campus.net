using System.Linq;
using Campus.net.DAL_Impl_EFCore.Data.ContextFolder;
using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using Campus.net.DAL_Impl_EFCore.Mappers.Implementation.AdditionalData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.AdditionalData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.MainData;
using Campus.net.Domain.MainData;
using Campus.net.Shared;

namespace Campus.net.DAL_Impl_EFCore.Mappers.Implementation.MainData
{
    internal sealed class SpecializationMapper : ISpecializationMapper
    {
        private readonly CampusDbContext _context;
        private readonly IGroupMapper _groupMapper;
        private readonly ISubjectDataMapper _subjectDataMapper;

        public SpecializationMapper(CampusDbContext context)
        {
            _context = context;
            _groupMapper = new GroupMapper(_context);
            _subjectDataMapper = new SubjectDataMapper(_context);
        }

        public Specialization EntityToModel(SpecializationDbModel item)
        {
            var specializationDbModel = _context.Specializations.Find(item.Id);
            _context.Entry(specializationDbModel).Collection(s=>s.GroupDbModels).Load();
            _context.Entry(specializationDbModel).Collection(s=>s.SubjectDataDbModels).Load();
            var groups = (from gp in specializationDbModel.GroupDbModels select _groupMapper.EntityToModel(gp)).ToList();
            var subjectDatas = (from subjectData in specializationDbModel.SubjectDataDbModels select _subjectDataMapper.EntityToModel(subjectData)).ToList();
            return new Specialization(
                groups,
                subjectDatas,
                item.Id,
                item.Name,
                item.SpecialtyDbModelId,
                item.DepartmentDbModelId
                );
        }

        public SpecializationDbModel ModelToEntity(Specialization item)
        {
            CustomValidator.ValidateObject(item);
            return new SpecializationDbModel(
                item.Id,
                item.Name,
                item.SpecialtyId,
                item.DepartmentId
                );
        }
    }
}
