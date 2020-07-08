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
    public sealed class PersonDataRepository : IPersonDataRepository
    {
        private readonly CampusDbContext _context;
        private readonly IPersonDataMapper _personDataMapper;
        public PersonDataRepository(CampusDbContext context)
        {
            _context = context;
            _personDataMapper = new PersonDataMapper();
        }
        public void AddOne(PersonData item)
        {
            CustomValidator.ValidateObject(item);
            if (!Exists(item.Id))
            {
                _context.PersonDatas.Add(_personDataMapper.ModelToEntity(item));
                _context.SaveChanges();
            }
        }

        public void DeleteOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var item = _context.PersonDatas.Find(id);
            if (item != null)
            {
                _context.PersonDatas.Remove(item);
                _context.SaveChanges();
            }
        }
        public void Detach(Guid id)
        {
            var entity = _context.PersonDatas.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return _context.PersonDatas.Any(item => item.Id.Equals(id));
        }

        public IEnumerable<PersonData> GetAll()
        {
            return (from itemDbModel in _context.PersonDatas select _personDataMapper.EntityToModel(itemDbModel)).ToList();
        }

        public PersonData GetOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var itemDbModel = _context.PersonDatas.Find(id);
            if (itemDbModel == null)
            {
                return null;
            }
            else
            {
                return _personDataMapper.EntityToModel(itemDbModel);
            }
        }

        public void UpdateOne(PersonData item)
        {
            CustomValidator.ValidateObject(item);
            if (Exists(item.Id))
            {
                var itemDbModel = _personDataMapper.ModelToEntity(item);
                Detach(itemDbModel.Id);
                var enState = _context.PersonDatas.Update(itemDbModel);
                enState.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
