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
    internal sealed class SpecializationMapper : IMapper<Specialization, SpecializationDbModel>
    {
        private readonly CampusDbContext _context;
        private readonly GroupMapper _groupMapper;
        private readonly SubjectDataMapper _subjectDataMapper;
        public Specialization ModelToEntity(SpecializationDbModel item)
        {
            CustomValidator.ValidateObject(item);
            var specializationDbModel = _context.Specializations.Where(s => s.Id.Equals(item.Id)).Include(s => s.GroupDbModels).Include(s => s.SubjectDataDbModels).FirstOrDefault();
            var groups = (from gp in specializationDbModel.GroupDbModels select _groupMapper.ModelToEntity(gp)).ToList();
            var subjectDatas = (from subjectData in specializationDbModel.SubjectDataDbModels select _subjectDataMapper.ModelToEntity(subjectData)).ToList();
            return new Specialization(
                groups,
                subjectDatas,
                item.Id,
                item.Name,
                item.SpecialtyDbModelId,
                item.DepartmentDbModelId
                );
        }

        public SpecializationDbModel EntityToModel(Specialization item)
        {
            CustomValidator.ValidateObject(item);
            return new SpecializationDbModel(
                item.Id,
                item.Name,
                item.SpecialtyId,
                item.DepartmentId
                );
        }

        public SpecializationMapper(CampusDbContext context)
        {
            _context = context;
            _groupMapper = new GroupMapper(_context);
            _subjectDataMapper = new SubjectDataMapper(_context);
        }
    }
}
