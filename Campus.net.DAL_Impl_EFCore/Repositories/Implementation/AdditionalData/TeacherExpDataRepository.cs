using Campus.net.DAL.RepoInterfaces.AdditionalData;
using Campus.net.DAL_Impl_EFCore.Data.ContextFolder;
using Campus.net.DAL_Impl_EFCore.Mappers.Implementation.AdditionalData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.AdditionalData;
using Campus.net.Domain.AdditionalData;
using Campus.net.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.Repositories.Implementation.AdditionalData
{
    public sealed class TeacherExpDataRepository : ITeacherExpDataRepository
    {
        private readonly CampusDbContext _context;
        private readonly ITeacherExpDataMapper _teacherExpDataMapper;
        public TeacherExpDataRepository(CampusDbContext context)
        {
            _context = context;
            _teacherExpDataMapper = new TeacherExpDataMapper();
        }
        public void AddOne(TeacherExpData item)
        {
            CustomValidator.ValidateObject(item);
            if (!Exists(item.Id))
            {
                _context.TeacherExpDatas.Add(_teacherExpDataMapper.ModelToEntity(item));
                _context.SaveChanges();
            }
        }

        public void DeleteOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var item = _context.TeacherExpDatas.Find(id);
            if (item != null)
            {
                _context.TeacherExpDatas.Remove(item);
                _context.SaveChanges();
            }
        }
        public void Detach(Guid id)
        {
            var entity = _context.TeacherExpDatas.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return _context.TeacherExpDatas.Any(item => item.Id.Equals(id));
        }

        public IEnumerable<TeacherExpData> GetAll()
        {
            return (from itemDbModel in _context.TeacherExpDatas select _teacherExpDataMapper.EntityToModel(itemDbModel)).ToList();
        }

        public TeacherExpData GetOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var itemDbModel = _context.TeacherExpDatas.Find(id);
            if (itemDbModel == null)
            {
                return null;
            }
            else
            {
                return _teacherExpDataMapper.EntityToModel(itemDbModel);
            }
        }

        public void UpdateOne(TeacherExpData item)
        {
            CustomValidator.ValidateObject(item);
            if (Exists(item.Id))
            {
                var itemDbModel = _teacherExpDataMapper.ModelToEntity(item);
                Detach(itemDbModel.Id);
                var enState = _context.TeacherExpDatas.Update(itemDbModel);
                enState.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
