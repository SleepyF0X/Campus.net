using System.Linq;
using Campus.net.DAL_Impl_EFCore.Data.ContextFolder;
using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.MainData;
using Campus.net.Domain.MainData;


namespace Campus.net.DAL_Impl_EFCore.Mappers.Implementation.MainData
{
    internal sealed class SpecialtyMapper : ISpecialtyMapper
    {
        private readonly CampusDbContext _context;
        private readonly ISpecializationMapper _specializationMapper;

        public SpecialtyMapper(CampusDbContext context)
        {
            _context = context;
            _specializationMapper = new SpecializationMapper(_context);
        }

        public Specialty EntityToModel(SpecialtyDbModel item)
        {
            var specialtyDbModel = _context.Specialties.Find(item.Id);
            _context.Entry(specialtyDbModel).Collection(s=>s.SpecializationDbModels).Load();
            var specializations = (from specialization in specialtyDbModel.SpecializationDbModels select _specializationMapper.EntityToModel(specialization)).ToList();
            return new Specialty(
                specializations,
                item.Id,
                item.Name,
                item.Number
                );
        }

        public SpecialtyDbModel ModelToEntity(Specialty item)
        {
            return new SpecialtyDbModel(
                item.Id,
                item.Name,
                item.Number
                );
        }
    }
}
