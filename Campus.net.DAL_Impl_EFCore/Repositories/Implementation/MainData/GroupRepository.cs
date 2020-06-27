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
    public sealed class GroupRepository : IGroupRepository
    {
        private readonly CampusDbContext _context;
        private readonly IGroupMapper _groupMapper;
        public GroupRepository(CampusDbContext context)
        {
            _context = context;
            _groupMapper = new GroupMapper(context);
        }
        public void AddOne(Group item)
        {
            CustomValidator.ValidateObject(item);
            if (!Exists(item.Id))
            {
                _context.Groups.Add(_groupMapper.ModelToEntity(item));
                _context.SaveChanges();
            }
        }

        public void DeleteOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var item = _context.Groups.Find(id);
            if (item != null)
            {
                _context.Groups.Remove(item);
                _context.SaveChanges();
            }
        }
        public void Detach(Guid id)
        {
            var entity = _context.Groups.Find(id);
            _context.Entry(entity).State = EntityState.Detached;
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return _context.Groups.Any(item => item.Id.Equals(id));
        }

        public IEnumerable<Group> GetAll()
        {
            return (from itemDbModel in _context.Groups select _groupMapper.EntityToModel(itemDbModel)).ToList();
        }

        public Group GetOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var itemDbModel = _context.Groups.Find(id);
            if (itemDbModel == null)
            {
                return null;
            }
            else
            {
                return _groupMapper.EntityToModel(itemDbModel);
            }
        }

        public void UpdateOne(Group item)
        {
            CustomValidator.ValidateObject(item);
            if (Exists(item.Id))
            {
                var itemDbModel = _groupMapper.ModelToEntity(item);
                Detach(itemDbModel.Id);
                var enState = _context.Groups.Update(itemDbModel);
                enState.State = EntityState.Modified;
                _context.SaveChanges();
            }
        }
    }
}
