using System.Linq;
using Campus.net.DAL_Impl_EFCore.Data.ContextFolder;
using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.MainData;
using Campus.net.Domain.MainData;

namespace Campus.net.DAL_Impl_EFCore.Mappers.Implementation.MainData
{
    internal sealed class DepartmentMapper : IDepartmentMapper
    {
        private readonly CampusDbContext _context;
        private readonly ISpecializationMapper _specializationMapper;
        private readonly ITeacherMapper _teacherMapper;

        public DepartmentMapper(CampusDbContext context)
        {
            _context = context;
            _specializationMapper = new SpecializationMapper(_context);
            _teacherMapper = new TeacherMapper(_context);
        }

        public Department DbToDomain(DepartmentDbModel item)
        {
            var departmentDbModel = _context.Departments.Find(item.Id);
            _context.Entry(departmentDbModel).Collection(d => d.SpecializationDbModels).Load();
            _context.Entry(departmentDbModel).Collection(d=>d.TeacherDbModels).Load();
            var specializations = (from specialization in departmentDbModel.SpecializationDbModels select _specializationMapper.DbToDomain(specialization)).ToList();
            var teachers = (from teacher in departmentDbModel.TeacherDbModels select _teacherMapper.DbToDomain(teacher)).ToList();
            return new Department(
                specializations,
                teachers,
                item.Id,
                item.Name,
                item.FacultyDbModelId
                );
        }

        public DepartmentDbModel DomainToDb(Department item)
        {
            return new DepartmentDbModel(
                item.Id,
                item.Name,
                item.FacultyId
                );
        }
    }
}
