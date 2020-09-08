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
    public sealed class SpecialtyRepository : ISpecialtyRepository
    {
        private readonly CampusDbContext _context;
        private readonly ISpecialtyMapper _specialtyMapper;
        public SpecialtyRepository(CampusDbContext context)
        {
            _context = context;
            _specialtyMapper = new SpecialtyMapper(context);
        }
        public void AddOne(Specialty item)
        {
            CustomValidator.ValidateObject(item);
            if (!Exists(item.Id))
            {
                _context.Specialties.Add(_specialtyMapper.ModelToEntity(item));
                _context.SaveChanges();
            }
        }

        public void DeleteOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var item = _context.Specialties.Find(id);
            if (item != null)
            {
                _context.Specialties.Remove(item);
                _context.SaveChanges();
            }
        }
        public void Detach(Guid id)
        {
            var entity = _context.Specialties.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return _context.Specialties.Any(item => item.Id.Equals(id));
        }

        public IEnumerable<Specialty> GetAll()
        {
            return (from itemDbModel in _context.Specialties select _specialtyMapper.EntityToModel(itemDbModel)).ToList();
        }

        public Specialty GetOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var itemDbModel = _context.Specialties.Find(id);
            if (itemDbModel == null)
            {
                return null;
            }
            else
            {
                return _specialtyMapper.EntityToModel(itemDbModel);
            }
        }

        public void UpdateOne(Specialty item)
        {
            CustomValidator.ValidateObject(item);
            if (Exists(item.Id))
            {
                var itemDbModel = _specialtyMapper.ModelToEntity(item);
                Detach(itemDbModel.Id);
                var enState = _context.Specialties.Update(itemDbModel);
                enState.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
