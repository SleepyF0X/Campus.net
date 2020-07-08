using Campus.net.DAL_Impl_EFCore.Data.ContextFolder;
using Campus.net.DAL_Impl_EFCore.DbModels.RelationClasses;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.Relational;
using Campus.net.Domain.RelationClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.Mappers.Implementation.Relational
{
    internal sealed class TeacherSubjectMapper : ITeacherSubjectMapper
    {
        private readonly CampusDbContext _context;
        public TeacherSubjectMapper(CampusDbContext context)
        {
            _context = context;
        }
        public TeacherSubject EntityToModel(TeacherSubjectDbModel item)
        {
            return new TeacherSubject(item.Id, item.TeacherDbModelId, item.SubjectDbModelId);
        }

        public TeacherSubjectDbModel ModelToEntity(TeacherSubject item)
        {
            var teacherExists = _context.Teachers.Find(item.TeacherId);
            var subjectExists = _context.Subjects.Find(item.SubjectId);
            if (teacherExists != null && subjectExists != null)
            {
                return new TeacherSubjectDbModel(item.Id, item.TeacherId, item.SubjectId);
            }
            else
            {
                return null;
            }
        }
    }
}
