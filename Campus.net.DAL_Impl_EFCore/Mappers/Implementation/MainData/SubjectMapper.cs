using System.Collections.Generic;
using System.Linq;
using Campus.net.DAL_Impl_EFCore.Data.ContextFolder;
using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using Campus.net.DAL_Impl_EFCore.DbModels.RelationClasses;
using Campus.net.DAL_Impl_EFCore.Mappers.Implementation.AdditionalData;
using Campus.net.DAL_Impl_EFCore.Mappers.Implementation.Relational;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.AdditionalData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.MainData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.Relational;
using Campus.net.Domain.MainData;

namespace Campus.net.DAL_Impl_EFCore.Mappers.Implementation.MainData
{
    internal sealed class SubjectMapper : ISubjectMapper
    {
        private readonly CampusDbContext _context;
        private readonly ITeacherSubjectGroupMapper _tsgMapper;
        private readonly ISubjectDataMapper _subjectDataMapper;

        public SubjectMapper(CampusDbContext context)
        {
            _context = context;
            _tsgMapper = new TeacherSubjectGroupMapper(context);
            _subjectDataMapper = new SubjectDataMapper(context);
        }

        public SubjectDbModel ModelToEntity(Subject item)
        {
            return new SubjectDbModel(item.Id, item.Name);
        }

        public Subject EntityToModel(SubjectDbModel item)
        {
            var tsDbModelLinks = _context.TeacherSubjects.Where(ts => ts.SubjectDbModelId.Equals(item.Id)).ToList();
            var tsgDbModelList = new List<TeacherSubject_GroupDbModel>();
            foreach (var ts in tsDbModelLinks)
            {
                tsgDbModelList.AddRange(_context.TeacherSubject_Groups.ToList().Where(tsg => tsg.TeacherSubjectDbModelId.Equals(ts.Id)));
            }
            return new Subject
            (
                (from subjectDataDbModel in item.SubjectDataDbModels select _subjectDataMapper.EntityToModel(subjectDataDbModel)).ToList(),
                item.Id,
                item.SubjectName
            );
        }
    }
}