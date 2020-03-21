using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using Campus.net.Domain.MainData;
using Campus.net.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.Mappers
{
    internal sealed class FacultyMapper : IMapper<Faculty, FacultyDbModel>
    {
        private readonly CampusDbContext _context;
        private readonly DepartmentMapper _departmentMapper;
        public Faculty ModelToEntity(FacultyDbModel item)
        {
            CustomValidator.ValidateObject(item);
            var facultyDbModel = _context.Faculties.Where(f => f.Id.Equals(item.Id)).Include(f => f.DepartmentDbModels).FirstOrDefault();
            var departments = (from department in facultyDbModel.DepartmentDbModels select _departmentMapper.ModelToEntity(department)).ToList();
            return new Faculty(
                departments, 
                item.Id, 
                item.Name
                );
        }

        public FacultyDbModel EntityToModel(Faculty item)
        {
            CustomValidator.ValidateObject(item);
            return new FacultyDbModel(
                item.Id,
                item.Name
                );
        }

        public FacultyMapper(CampusDbContext context)
        {
            _context = context;
            _departmentMapper = new DepartmentMapper(_context);
        }
    }
}
