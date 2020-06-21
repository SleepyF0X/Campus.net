using System.Linq;
using Campus.net.DAL_Impl_EFCore.Data.ContextFolder;
using Campus.net.DAL_Impl_EFCore.DbModels.RelationClasses;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.Relational;
using Campus.net.Domain.RelationClasses;

namespace Campus.net.DAL_Impl_EFCore.Mappers.Implementation.Relational
{
    internal  sealed class TsgMapper : ITsgMapper
    {
        private readonly CampusDbContext _context;
        public TsgMapper(CampusDbContext context)
        {
            _context = context;
        }
        public TeacherSubject_GroupDbModel ModelToEntity(TeacherSubjectGroup item)
        {
            var tsDbModelLink = _context.TeacherSubjects
                .FirstOrDefault(ts => ts.TeacherDbModelId.Equals(item.TeacherId) && ts.SubjectDbModelId.Equals(item.SubjectId));
            return new TeacherSubject_GroupDbModel(item.Id, tsDbModelLink.Id, item.GroupId);
        }

        public TeacherSubjectGroup EntityToModel(TeacherSubject_GroupDbModel item)
        {
            var tsDbModelLink = _context.TeacherSubjects.Find(item.TeacherSubjectDbModelId);
            return new TeacherSubjectGroup(item.Id, tsDbModelLink.TeacherDbModelId, tsDbModelLink.SubjectDbModelId, item.GroupDbModelId);
        }
    }
}
