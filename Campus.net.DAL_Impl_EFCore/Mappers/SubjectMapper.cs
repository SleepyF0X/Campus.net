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
    internal sealed class SubjectMapper : IMapper<Subject, SubjectDbModel>
    {
        private readonly CampusDbContext _context;
        private readonly TsgMapper _tsgMapper;
        private readonly SubjectDataMapper _subjectDataMapper;

        public SubjectMapper(CampusDbContext context)
        {
            _context = context;
            _tsgMapper = new TsgMapper(context);
            _subjectDataMapper = new SubjectDataMapper(context);
        }

        public SubjectDbModel EntityToModel(Subject item)
        {
            CustomValidator.ValidateObject(item);
            return new SubjectDbModel(item.Id, item.Name);
        }

        public Subject ModelToEntity(SubjectDbModel item)
        {
            CustomValidator.ValidateObject(item);
            var tsDbModelLinks = _context.TeacherSubjects.Where(ts => ts.SubjectDbModelId.Equals(item.Id)).ToList();
            CustomValidator.ValidateObject(tsDbModelLinks);
            var tsgDbModelList = new List<TeacherSubject_GroupDbModel>();
            foreach (var ts in tsDbModelLinks)
            {
                tsgDbModelList.AddRange(_context.TeacherSubject_Groups.ToList().Where(tsg => tsg.TeacherSubjectDbModelId.Equals(ts.Id)));
            }
            CustomValidator.ValidateObject(tsgDbModelList);
            return new Subject
            (
                (from teacherSubjectGroupDbModel in tsgDbModelList select _tsgMapper.ModelToEntity(teacherSubjectGroupDbModel)).ToList(),
                (from subjectDataDbModel in item.SubjectDataDbModels select _subjectDataMapper.ModelToEntity(subjectDataDbModel)).ToList(),
                item.Id,
                item.SubjectName
            );
        }
    }
}