using System.Linq;
using Campus.net.DAL_Impl_EFCore.Data.ContextFolder;
using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.MainData;
using Campus.net.Domain.MainData;


namespace Campus.net.DAL_Impl_EFCore.Mappers.Implementation.MainData
{
    internal sealed class FacultyMapper : IFacultyMapper
    {
        private readonly CampusDbContext _context;
        private readonly IDepartmentMapper _departmentMapper;

        public FacultyMapper(CampusDbContext context)
        {
            _context = context;
            _departmentMapper = new DepartmentMapper(_context);
        }

        public Faculty DbToDomain(FacultyDbModel item)
        {
            var facultyDbModel = _context.Faculties.Find(item.Id);
            _context.Entry(facultyDbModel).Collection(f => f.DepartmentDbModels).Load();
            var departments = (from department in facultyDbModel.DepartmentDbModels select _departmentMapper.DbToDomain(department)).ToList();
            return new Faculty(
                departments, 
                item.Id, 
                item.Name
                );
        }

        public FacultyDbModel DomainToDb(Faculty item)
        {
            return new FacultyDbModel(
                item.Id,
                item.Name
                );
        }
    }
}
