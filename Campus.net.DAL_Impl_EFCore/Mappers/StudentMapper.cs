using System;
using System.Collections.Generic;
using System.Text;
using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using Campus.net.Domain.MainData;
using Campus.net.Shared;

namespace Campus.net.DAL_Impl_EFCore.Mappers
{
    internal sealed class StudentMapper : IMapper<Student, StudentDbModel>
    {
        private readonly CampusDbContext _context;
        private readonly PersonDataMapper _personDataMapper;
        private readonly StudentDataMapper _studentDataMapper;

        public StudentMapper(CampusDbContext context)
        {
            _context = context;
            _personDataMapper = new PersonDataMapper();
            _studentDataMapper = new StudentDataMapper(context);
        }
        public StudentDbModel EntityToModel(Student item)
        {
            CustomValidator.ValidateObject(item);
            return new StudentDbModel(item.Id, item.PersonData.Id, item.StudentData.Id, item.GroupId);
        }

        public Student ModelToEntity(StudentDbModel item)
        {
            CustomValidator.ValidateObject(item);
            return new Student(
                item.Id,
                _personDataMapper.ModelToEntity(_context.PersonDatas.Find(item.PersonDataDbModelId)),
                _studentDataMapper.ModelToEntity(_context.StudentDatas.Find(item.StudentDataDbModelId)),
                item.GroupDbModelId
                );
        }
    }
}
