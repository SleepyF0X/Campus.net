using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.net.DAL_Impl_EFCore.DbModels.RelationClasses;
using Campus.net.Domain.RelationClasses;
using Campus.net.Shared;

namespace Campus.net.DAL_Impl_EFCore.Mappers
{
    internal  sealed class TsgMapper : IMapper<TeacherSubjectGroup, TeacherSubject_GroupDbModel>
    {
        private readonly CampusDbContext _context;
        public TsgMapper(CampusDbContext context)
        {
            _context = context;
        }
        public TeacherSubject_GroupDbModel EntityToModel(TeacherSubjectGroup item)
        {
            CustomValidator.ValidateObject(item);
            var tsDbModelLink = _context.TeacherSubjects
                .FirstOrDefault(ts => ts.TeacherDbModelId.Equals(item.TeacherId) && ts.SubjectDbModelId.Equals(item.SubjectId));
            CustomValidator.ValidateObject(tsDbModelLink);
            return new TeacherSubject_GroupDbModel(item.Id, tsDbModelLink.Id, item.GroupId);
        }

        public TeacherSubjectGroup ModelToEntity(TeacherSubject_GroupDbModel item)
        {
            CustomValidator.ValidateObject(item);
            var tsDbModelLink = _context.TeacherSubjects.Find(item.TeacherSubjectDbModelId);
            CustomValidator.ValidateObject(tsDbModelLink);
            return new TeacherSubjectGroup(item.Id, tsDbModelLink.TeacherDbModelId, tsDbModelLink.SubjectDbModelId, item.GroupDbModelId);
        }
    }
}
