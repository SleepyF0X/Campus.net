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
    public sealed class TeacherSubjectRepository : ITeacherSubjectRepository
    {
        private readonly CampusDbContext _context;
        private readonly ITeacherSubjectMapper _teacherSubjectMapper;
        public TeacherSubjectRepository(CampusDbContext context)
        {
            _context = context;
            _teacherSubjectMapper = new TeacherSubjectMapper(context);
        }
        public void AddOne(TeacherSubject item)
        {
            CustomValidator.ValidateObject(item);
            if (!Exists(item.Id))
            {
                _context.TeacherSubjects.Add(_teacherSubjectMapper.ModelToEntity(item));
                _context.SaveChanges();
            }
        }

        public void DeleteOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var item = _context.TeacherSubjects.Find(id);
            if (item != null)
            {
                _context.TeacherSubjects.Remove(item);
                _context.SaveChanges();
            }
        }
        public void Detach(Guid id)
        {
            var entity = _context.TeacherSubjects.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return _context.TeacherSubjects.Any(item => item.Id.Equals(id));
        }

        public IEnumerable<TeacherSubject> GetAll()
        {
            return (from itemDbModel in _context.TeacherSubjects select _teacherSubjectMapper.EntityToModel(itemDbModel)).ToList();
        }

        public TeacherSubject GetOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var itemDbModel = _context.TeacherSubjects.Find(id);
            if (itemDbModel == null)
            {
                return null;
            }
            else
            {
                return _teacherSubjectMapper.EntityToModel(itemDbModel);
            }
        }

        public void UpdateOne(TeacherSubject item)
        {
            CustomValidator.ValidateObject(item);
            if (Exists(item.Id))
            {
                var itemDbModel = _teacherSubjectMapper.ModelToEntity(item);
                Detach(itemDbModel.Id);
                var enState = _context.TeacherSubjects.Update(itemDbModel);
                enState.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
