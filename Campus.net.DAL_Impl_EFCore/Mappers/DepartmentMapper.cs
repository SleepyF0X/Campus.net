using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using Campus.net.Domain.MainData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Campus.net.Shared;
using Microsoft.EntityFrameworkCore;

namespace Campus.net.DAL_Impl_EFCore.Mappers
{
    internal sealed class DepartmentMapper : IMapper<Department, DepartmentDbModel>
    {
        private readonly CampusDbContext _context;
        private readonly SpecializationMapper _specializationMapper;
        private readonly TeacherMapper _teacherMapper;
        public Department ModelToEntity(DepartmentDbModel item)
        {
            CustomValidator.ValidateObject(item);
            var departmentDbModel = _context.Departments.Where(d => d.Id.Equals(item.Id)).Include(d => d.SpecializationDbModels).Include(d => d.TeacherDbModels).FirstOrDefault();
            var specializations = (from specialization in departmentDbModel.SpecializationDbModels select _specializationMapper.ModelToEntity(specialization)).ToList();
            var teachers = (from teacher in departmentDbModel.TeacherDbModels select _teacherMapper.ModelToEntity(teacher)).ToList();
            return new Department(
                specializations,
                teachers,
                item.Id,
                item.Name,
                item.FacultyDbModelId
                );
        }

        public DepartmentDbModel EntityToModel(Department item)
        {
            CustomValidator.ValidateObject(item);
            return new DepartmentDbModel(
                item.Id,
                item.Name,
                item.FacultyId
                );
        }

        public DepartmentMapper(CampusDbContext context)
        {
            _context = context;
            _specializationMapper = new SpecializationMapper(_context);
            _teacherMapper = new TeacherMapper(_context);
        }
    }
}
