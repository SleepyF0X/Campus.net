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
    public sealed class SubjectDataRepository : ISubjectDataRepository
    {
        private readonly CampusDbContext _context;
        private readonly ISubjectDataMapper _subjectDataMapper;
        public SubjectDataRepository(CampusDbContext context)
        {
            _context = context;
            _subjectDataMapper = new SubjectDataMapper(context);
        }
        public void AddOne(SubjectData item)
        {
            CustomValidator.ValidateObject(item);
            if (!Exists(item.Id))
            {
                _context.SubjectDatas.Add(_subjectDataMapper.ModelToEntity(item));
                _context.SaveChanges();
            }
        }

        public void DeleteOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var item = _context.SubjectDatas.Find(id);
            if (item != null)
            {
                _context.SubjectDatas.Remove(item);
                _context.SaveChanges();
            }
        }
        public void Detach(Guid id)
        {
            var entity = _context.SubjectDatas.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return _context.SubjectDatas.Any(item => item.Id.Equals(id));
        }

        public IEnumerable<SubjectData> GetAll()
        {
            return (from itemDbModel in _context.SubjectDatas select _subjectDataMapper.EntityToModel(itemDbModel)).ToList();
        }

        public SubjectData GetOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var itemDbModel = _context.SubjectDatas.Find(id);
            if (itemDbModel == null)
            {
                return null;
            }
            else
            {
                return _subjectDataMapper.EntityToModel(itemDbModel);
            }
        }

        public void UpdateOne(SubjectData item)
        {
            CustomValidator.ValidateObject(item);
            if (Exists(item.Id))
            {
                var itemDbModel = _subjectDataMapper.ModelToEntity(item);
                Detach(itemDbModel.Id);
                var enState = _context.SubjectDatas.Update(itemDbModel);
                enState.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
