using Campus.net.DAL_Impl_EFCore.Data.ContextFolder;
using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using Campus.net.DAL_Impl_EFCore.Mappers.Implementation.AdditionalData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.AdditionalData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.MainData;
using Campus.net.Domain.MainData;

namespace Campus.net.DAL_Impl_EFCore.Mappers.Implementation.MainData
{
    internal sealed class StudentMapper : IStudentMapper
    {
        private readonly CampusDbContext _context;
        private readonly IPersonDataMapper _personDataMapper;
        private readonly IStudentDataMapper _studentDataMapper;

        public StudentMapper(CampusDbContext context)
        {
            _context = context;
            _personDataMapper = new PersonDataMapper();
            _studentDataMapper = new StudentDataMapper(context);
        }

        public StudentDbModel DomainToDb(Student item)
        {
            return new StudentDbModel(item.Id, item.PersonData.Id, item.StudentData.Id, item.GroupId);
        }

        public Student DbToDomain(StudentDbModel item)
        {
            return new Student(
                item.Id,
                _personDataMapper.DbToDomain(_context.PersonDatas.Find(item.PersonDataDbModelId)),
                _studentDataMapper.DbToDomain(_context.StudentDatas.Find(item.StudentDataDbModelId)),
                item.GroupDbModelId
                );
        }
    }
}
