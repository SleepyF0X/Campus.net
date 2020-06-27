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
    public sealed class StudentDataRepository : IStudentDataRepository
    {
        private readonly CampusDbContext _context;
        private readonly IStudentDataMapper _studentDataMapper;
        public StudentDataRepository(CampusDbContext context)
        {
            _context = context;
            _studentDataMapper = new StudentDataMapper(context);
        }
        public void AddOne(StudentData item)
        {
            CustomValidator.ValidateObject(item);
            if (!Exists(item.Id))
            {
                _context.StudentDatas.Add(_studentDataMapper.ModelToEntity(item));
                _context.SaveChanges();
            }
        }

        public void DeleteOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var item = _context.StudentDatas.Find(id);
            if (item != null)
            {
                _context.StudentDatas.Remove(item);
                _context.SaveChanges();
            }
        }
        public void Detach(Guid id)
        {
            var entity = _context.StudentDatas.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return _context.StudentDatas.Any(item => item.Id.Equals(id));
        }

        public IEnumerable<StudentData> GetAll()
        {
            return (from itemDbModel in _context.StudentDatas select _studentDataMapper.EntityToModel(itemDbModel)).ToList();
        }

        public StudentData GetOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var itemDbModel = _context.StudentDatas.Find(id);
            if (itemDbModel == null)
            {
                return null;
            }
            else
            {
                return _studentDataMapper.EntityToModel(itemDbModel);
            }
        }

        public void UpdateOne(StudentData item)
        {
            CustomValidator.ValidateObject(item);
            if (Exists(item.Id))
            {
                var itemDbModel = _studentDataMapper.ModelToEntity(item);
                Detach(itemDbModel.Id);
                var enState = _context.StudentDatas.Update(itemDbModel);
                enState.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
