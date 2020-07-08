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
    public sealed class SubjectRepository : ISubjectRepository
    {
        private readonly CampusDbContext _context;
        private readonly ISubjectMapper _subjectMapper;
        public SubjectRepository(CampusDbContext context)
        {
            _context = context;
            _subjectMapper = new SubjectMapper(context);
        }
        public void AddOne(Subject item)
        {
            CustomValidator.ValidateObject(item);
            if (!Exists(item.Id))
            {
                _context.Subjects.Add(_subjectMapper.ModelToEntity(item));
                _context.SaveChanges();
            }
        }

        public void DeleteOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var item = _context.Subjects.Find(id);
            if (item != null)
            {
                _context.Subjects.Remove(item);
                _context.SaveChanges();
            }
        }
        public void Detach(Guid id)
        {
            var entity = _context.Subjects.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return _context.Subjects.Any(item => item.Id.Equals(id));
        }

        public IEnumerable<Subject> GetAll()
        {
            return (from itemDbModel in _context.Subjects select _subjectMapper.EntityToModel(itemDbModel)).ToList();
        }

        public Subject GetOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var itemDbModel = _context.Subjects.Find(id);
            if (itemDbModel == null)
            {
                return null;
            }
            else
            {
                return _subjectMapper.EntityToModel(itemDbModel);
            }
        }

        public void UpdateOne(Subject item)
        {
            CustomValidator.ValidateObject(item);
            if (Exists(item.Id))
            {
                var itemDbModel = _subjectMapper.ModelToEntity(item);
                Detach(itemDbModel.Id);
                var enState = _context.Subjects.Update(itemDbModel);
                enState.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
