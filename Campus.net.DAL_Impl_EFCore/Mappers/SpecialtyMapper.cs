using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using Campus.net.Domain.MainData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.net.Shared;
using Microsoft.EntityFrameworkCore;

namespace Campus.net.DAL_Impl_EFCore.Mappers
{
    internal sealed class SpecialtyMapper : IMapper<Specialty, SpecialtyDbModel>
    {
        private readonly CampusDbContext _context;
        private readonly SpecializationMapper _specializationMapper;
        public Specialty ModelToEntity(SpecialtyDbModel item)
        {
            CustomValidator.ValidateObject(item);
            var specialtyDbModel = _context.Specialties.Where(s => s.Id.Equals(item.Id)).Include(s => s.SpecializationDbModels).FirstOrDefault();
            var specializations = (from specialization in specialtyDbModel.SpecializationDbModels select _specializationMapper.ModelToEntity(specialization)).ToList();
            return new Specialty(
                specializations,
                item.Id,
                item.Name,
                item.Number
                );
        }

        public SpecialtyDbModel EntityToModel(Specialty item)
        {
            CustomValidator.ValidateObject(item);
            return new SpecialtyDbModel(
                item.Id,
                item.Name,
                item.Number
                );
        }

        public SpecialtyMapper(CampusDbContext context)
        {
            _context = context;
            _specializationMapper = new SpecializationMapper(_context);
        }
    }
}
