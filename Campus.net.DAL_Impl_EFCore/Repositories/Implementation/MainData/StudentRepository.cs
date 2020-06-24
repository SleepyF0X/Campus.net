using Campus.net.DAL.RepoInterfaces;
using Campus.net.DAL.RepoInterfaces.MainData;
using Campus.net.DAL_Impl_EFCore.Data.ContextFolder;
using Campus.net.DAL_Impl_EFCore.Mappers.Implementation.MainData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.MainData;
using Campus.net.Domain.MainData;
using Campus.net.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore.Repositories.Implementation.MainData
{
    public sealed class StudentRepository : IStudentRepository, IDetachable<Student>
    {
        private readonly CampusDbContext context;
        private readonly IStudentMapper studentMapper;

        public StudentRepository(CampusDbContext context)
        {
            this.context = context;
            studentMapper = new StudentMapper(context);
        }
        public void AddOne(Student item)
        {
            CustomValidator.ValidateObject(item);
            if (!Exists(item.Id))
            {
                context.Students.Add(studentMapper.ModelToEntity(item));
                context.SaveChanges();
            }
        }

        public void DeleteOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var item = context.Students.Find(id);
            if (item != null)
            {
                context.Students.Remove(item);
                context.SaveChanges();
            }
        }

        public void Detach(Guid id)
        {
            var entity = context.Students.Find(id);
            context.Entry(entity).State = EntityState.Detached;
        }

        public bool Exists(Guid id)
        {
            CustomValidator.ValidateId(id);
            return context.Students.Any(item => item.Id.Equals(id));
        }

        public IEnumerable<Student> GetAll()
        {
            var items = (from itemDbModel in context.Students select studentMapper.EntityToModel(itemDbModel)).ToList();
            return items;
        }

        public Student GetOne(Guid id)
        {
            CustomValidator.ValidateId(id);
            var itemDbModel = context.Students.Find(id);
            if (itemDbModel == null)
            {
                return null;
            }
            else
            {
                return studentMapper.EntityToModel(itemDbModel);
            }
        }

        public void UpdateOne(Student item)
        {
            CustomValidator.ValidateObject(item);
            if (Exists(item.Id))
            {
                var itemDbModel = studentMapper.ModelToEntity(item);
                Detach(itemDbModel.Id);
                var enState = context.Students.Update(itemDbModel);
                enState.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
