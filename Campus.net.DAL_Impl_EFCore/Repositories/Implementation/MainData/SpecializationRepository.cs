using Campus.net.DAL.RepoInterfaces.MainData;
using Campus.net.DAL_Impl_EFCore.Data.ContextFolder;
using Campus.net.DAL_Impl_EFCore.Mappers.Implementation.MainData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.MainData;
using Campus.net.Domain.MainData;
using Campus.net.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.Repositories.Implementation.MainData
{
    public sealed class SpecializationRepository : ISpecializationRepository
    {
        private readonly CampusDbContext _context;
        private readonly ISpecializationMapper _specializationMapper;
        public SpecializationRepository(CampusDbContext context)
        {
            _context = context;
            _specializationMapper = new SpecializationMapper(context);
        }
        public void AddOne(Specialization item)
        {
            CustomValidator.ValidateObject(item);
            if (!Exists(item.Id))
            {
                _context.Specializations.Add(_specializationMapper.ModelToEntity(item));
                _context.SaveChanges();
            }
        }

        public void DeleteOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var item = _context.Specializations.Find(id);
            if (item != null)
            {
                _context.Specializations.Remove(item);
                _context.SaveChanges();
            }
        }
        public void Detach(Guid id)
        {
            var entity = _context.Specializations.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return _context.Specializations.Any(item => item.Id.Equals(id));
        }

        public IEnumerable<Specialization> GetAll()
        {
            return (from itemDbModel in _context.Specializations select _specializationMapper.EntityToModel(itemDbModel)).ToList();
        }

        public Specialization GetOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var itemDbModel = _context.Specializations.Find(id);
            if (itemDbModel == null)
            {
                return null;
            }
            else
            {
                return _specializationMapper.EntityToModel(itemDbModel);
            }
        }

        public void UpdateOne(Specialization item)
        {
            CustomValidator.ValidateObject(item);
            if (Exists(item.Id))
            {
                var itemDbModel = _specializationMapper.ModelToEntity(item);
                Detach(itemDbModel.Id);
                var enState = _context.Specializations.Update(itemDbModel);
                enState.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
