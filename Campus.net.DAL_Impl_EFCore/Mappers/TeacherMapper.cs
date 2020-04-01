using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using Campus.net.DAL_Impl_EFCore.DbModels.RelationClasses;
using Campus.net.Domain.MainData;
using Campus.net.Shared;

namespace Campus.net.DAL_Impl_EFCore.Mappers
{
    internal sealed class TeacherMapper : IMapper<Teacher, TeacherDbModel>
    {
        private readonly CampusDbContext _context;
        private readonly TsgMapper _tsgMapper;
        private readonly PersonDataMapper _personDataMapper;
        private readonly TeacherExpDataMapper _teacherExpDataMapper;
        public TeacherMapper(CampusDbContext context)
        {
            _context = context;
            _tsgMapper = new TsgMapper(context);
            _personDataMapper = new PersonDataMapper();
            _teacherExpDataMapper = new TeacherExpDataMapper();
        }

        public TeacherDbModel EntityToModel(Teacher item)
        {
            CustomValidator.ValidateObject(item);
            return new TeacherDbModel(item.Id, item.PersonData.Id, item.TeacherExpData.Id, item.DepartmentId);
        }

        public Teacher ModelToEntity(TeacherDbModel item)
        {
            CustomValidator.ValidateObject(item);
            var tsDbModelLinks = _context.TeacherSubjects.Where(ts => ts.TeacherDbModelId.Equals(item.Id)).ToList();
            CustomValidator.ValidateObject(tsDbModelLinks);
            var tsgDbModelList = new List<TeacherSubject_GroupDbModel>();
            foreach (var ts in tsDbModelLinks)
            {
                tsgDbModelList.AddRange(_context.TeacherSubject_Groups.ToList()
                    .Where(tsg => tsg.TeacherSubjectDbModelId.Equals(ts.Id)));
            }
            CustomValidator.ValidateObject(tsgDbModelList);
            return new Teacher(
                (from teacherSubjectGroupDbModel in tsgDbModelList select _tsgMapper.ModelToEntity(teacherSubjectGroupDbModel)).ToList(),
                item.Id,
                _personDataMapper.ModelToEntity(_context.PersonDatas.Find(item.PersonDataDbModelId)),
                _teacherExpDataMapper.ModelToEntity(_context.TeacherExpDatas.Find(item.TeacherExpDataDbModelId)),
                item.DepartmentDbModelId
            );
        }
    }
}
