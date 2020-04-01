using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using Campus.net.Domain.MainData;
using Campus.net.Shared;
using Microsoft.EntityFrameworkCore;

namespace Campus.net.DAL_Impl_EFCore.Mappers
{
    internal sealed class GroupMapper : IMapper<Group, GroupDbModel>
    {
        private readonly CampusDbContext _context;
        private readonly StudentMapper _studentMapper;
        private readonly TsgMapper _tsgMapper;
        public GroupMapper(CampusDbContext context)
        {
            _context = context;
            _studentMapper = new StudentMapper(context);
            _tsgMapper = new TsgMapper(context);
        }

        public GroupDbModel EntityToModel(Group item)
        {
            CustomValidator.ValidateObject(item);
            return new GroupDbModel(item.Id, item.GroupName, item.SpecializationId);
        }

        public Group ModelToEntity(GroupDbModel item)
        {
            CustomValidator.ValidateObject(item);
            var groupDbModel = _context.Groups
                .Where(g => g.Id.Equals(item.Id))
                .Include(g => g.StudentDbModels)
                .FirstOrDefault();
            CustomValidator.ValidateObject(groupDbModel);
            var tsgDbModelList = _context.TeacherSubject_Groups.Where(i=>i.GroupDbModelId.Equals(groupDbModel.Id)).ToList();
            CustomValidator.ValidateObject(tsgDbModelList);
            return new Group(
                (from studentDbModel in groupDbModel.StudentDbModels select _studentMapper.ModelToEntity(studentDbModel)).ToList(),
                (from tsg in tsgDbModelList select _tsgMapper.ModelToEntity(tsg)).ToList(),
                item.Id,
                item.GroupName, 
                item.SpecializationDbModelId
                );
        }
    }
}