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
    public sealed class FacultyRepository : IFacultyRepository
    {
        private readonly CampusDbContext _context;
        private readonly IFacultyMapper _facultyMapper;
        public FacultyRepository(CampusDbContext context)
        {
            _context = context;
            _facultyMapper = new FacultyMapper(context);
        }
        public void AddOne(Faculty item)
        {
            CustomValidator.ValidateObject(item);
            if (!Exists(item.Id))
            {
                _context.Faculties.Add(_facultyMapper.ModelToEntity(item));
                _context.SaveChanges();
            }
        }

        public void DeleteOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var item = _context.Faculties.Find(id);
            if (item != null)
            {
                _context.Faculties.Remove(item);
                _context.SaveChanges();
            }
        }
        public void Detach(Guid id)
        {
            var entity = _context.Faculties.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return _context.Faculties.Any(item => item.Id.Equals(id));
        }

        public IEnumerable<Faculty> GetAll()
        {
            return (from itemDbModel in _context.Faculties select _facultyMapper.EntityToModel(itemDbModel)).ToList();
        }

        public Faculty GetOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var itemDbModel = _context.Faculties.Find(id);
            if (itemDbModel == null)
            {
                return null;
            }
            else
            {
                return _facultyMapper.EntityToModel(itemDbModel);
            }
        }

        public void UpdateOne(Faculty item)
        {
            CustomValidator.ValidateObject(item);
            if (Exists(item.Id))
            {
                var itemDbModel = _facultyMapper.ModelToEntity(item);
                Detach(itemDbModel.Id);
                var enState = _context.Faculties.Update(itemDbModel);
                enState.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
