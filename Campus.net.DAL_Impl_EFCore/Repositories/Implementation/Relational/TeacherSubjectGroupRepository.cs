using Campus.net.DAL.RepoInterfaces.Relational;
using Campus.net.DAL_Impl_EFCore.Data.ContextFolder;
using Campus.net.DAL_Impl_EFCore.Mappers.Implementation.Relational;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.Relational;
using Campus.net.Domain.RelationClasses;
using Campus.net.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.Repositories.Implementation.Relational
{
    public sealed class TeacherSubjectGroupRepository : ITeacherSubjectGroupRepository
    {
        private readonly CampusDbContext _context;
        private readonly ITeacherSubjectGroupMapper _teacherSubjectGroupMapper;
        public TeacherSubjectGroupRepository(CampusDbContext context)
        {
            _context = context;
            _teacherSubjectGroupMapper = new TeacherSubjectGroupMapper(context);
        }
        public void AddOne(TeacherSubjectGroup item)
        {
            CustomValidator.ValidateObject(item);
            if (!Exists(item.Id))
            {
                _context.TeacherSubject_Groups.Add(_teacherSubjectGroupMapper.ModelToEntity(item));
                _context.SaveChanges();
            }
        }

        public void DeleteOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var item = _context.TeacherSubject_Groups.Find(id);
            if (item != null)
            {
                _context.TeacherSubject_Groups.Remove(item);
                _context.SaveChanges();
            }
        }
        public void Detach(Guid id)
        {
            var entity = _context.TeacherSubject_Groups.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return _context.TeacherSubject_Groups.Any(item => item.Id.Equals(id));
        }

        public IEnumerable<TeacherSubjectGroup> GetAll()
        {
            return (from itemDbModel in _context.TeacherSubject_Groups select _teacherSubjectGroupMapper.EntityToModel(itemDbModel)).ToList();
        }

        public TeacherSubjectGroup GetOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var itemDbModel = _context.TeacherSubject_Groups.Find(id);
            if (itemDbModel == null)
            {
                return null;
            }
            else
            {
                return _teacherSubjectGroupMapper.EntityToModel(itemDbModel);
            }
        }

        public void UpdateOne(TeacherSubjectGroup item)
        {
            CustomValidator.ValidateObject(item);
            if (Exists(item.Id))
            {
                var itemDbModel = _teacherSubjectGroupMapper.ModelToEntity(item);
                Detach(itemDbModel.Id);
                var enState = _context.TeacherSubject_Groups.Update(itemDbModel);
                enState.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
