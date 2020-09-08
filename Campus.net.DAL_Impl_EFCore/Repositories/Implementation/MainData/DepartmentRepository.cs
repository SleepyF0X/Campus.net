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
    public sealed class DepartmentRepository : IDepartmentRepository
    {
        private readonly CampusDbContext _context;
        private readonly IDepartmentMapper _departmentMapper;
        public DepartmentRepository(CampusDbContext context)
        {
            _context = context;
            _departmentMapper = new DepartmentMapper(context);
        }
        public void AddOne(Department item)
        {
            CustomValidator.ValidateObject(item);
            if (!Exists(item.Id))
            {
                _context.Departments.Add(_departmentMapper.ModelToEntity(item));
                _context.SaveChanges();
            }
        }

        public void DeleteOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var item = _context.Departments.Find(id);
            if (item != null)
            {
                _context.Departments.Remove(item);
                _context.SaveChanges();
            }
        }
        public void Detach(Guid id)
        {
            var entity = _context.Departments.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return _context.Departments.Any(item => item.Id.Equals(id));
        }

        public IEnumerable<Department> GetAll()
        {
            return (from itemDbModel in _context.Departments select _departmentMapper.EntityToModel(itemDbModel)).ToList();
        }

        public Department GetOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var itemDbModel = _context.Departments.Find(id);
            if (itemDbModel == null)
            {
                return null;
            }
            else
            {
                return _departmentMapper.EntityToModel(itemDbModel);
            }
        }

        public void UpdateOne(Department item)
        {
            CustomValidator.ValidateObject(item);
            if (Exists(item.Id))
            {
                var itemDbModel = _departmentMapper.ModelToEntity(item);
                Detach(itemDbModel.Id);
                var enState = _context.Departments.Update(itemDbModel);
                enState.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
