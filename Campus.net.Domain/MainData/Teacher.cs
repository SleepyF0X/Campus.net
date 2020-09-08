using Campus.net.Domain.AdditionalData;
using Campus.net.Domain.RelationClasses;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Campus.net.Domain.MainData
{
    public sealed class Teacher
    {
        public Guid Id { get; }
        public PersonData PersonData { get; }
        public TeacherExpData TeacherExpData { get; }
        public Guid DepartmentId { get; }

        public Teacher(Guid id, PersonData personData, TeacherExpData teacherExpData, Guid departmentId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateObject(personData);
            CustomValidator.ValidateObject(teacherExpData);
            CustomValidator.ValidateId(departmentId);
            Id = id;
            PersonData = personData;
            TeacherExpData = teacherExpData;
            DepartmentId = departmentId;
        }
    }
}