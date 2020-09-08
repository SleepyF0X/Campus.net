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
    public sealed class TeacherRepository : ITeacherRepository
    {
        private readonly CampusDbContext _context;
        private readonly ITeacherMapper _teacherMapper;
        public TeacherRepository(CampusDbContext context)
        {
            _context = context;
            _teacherMapper = new TeacherMapper(context);
        }
        public void AddOne(Teacher item)
        {
            CustomValidator.ValidateObject(item);
            if (!Exists(item.Id))
            {
                _context.Teachers.Add(_teacherMapper.ModelToEntity(item));
                _context.SaveChanges();
            }
        }

        public void DeleteOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var item = _context.Teachers.Find(id);
            if (item != null)
            {
                _context.Teachers.Remove(item);
                _context.SaveChanges();
            }
        }
        public void Detach(Guid id)
        {
            var entity = _context.Teachers.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return _context.Teachers.Any(item => item.Id.Equals(id));
        }

        public IEnumerable<Teacher> GetAll()
        {
            return (from itemDbModel in _context.Teachers select _teacherMapper.EntityToModel(itemDbModel)).ToList();
        }

        public Teacher GetOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var itemDbModel = _context.Teachers.Find(id);
            if (itemDbModel == null)
            {
                return null;
            }
            else
            {
                return _teacherMapper.EntityToModel(itemDbModel);
            }
        }

        public void UpdateOne(Teacher item)
        {
            CustomValidator.ValidateObject(item);
            if (Exists(item.Id))
            {
                var itemDbModel = _teacherMapper.ModelToEntity(item);
                Detach(itemDbModel.Id);
                var enState = _context.Teachers.Update(itemDbModel);
                enState.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
