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
        private readonly List<TeacherSubjectGroup> _teacherSubjectGroups;

        public IReadOnlyCollection<SubjectGroup> SubjectGroups =>
                (from tsg in _teacherSubjectGroups
                where tsg.TeacherId.Equals(Id)
                select new SubjectGroup(tsg.SubjectId, tsg.GroupId)).ToList().AsReadOnly();

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
            _teacherSubjectGroups = new List<TeacherSubjectGroup>();
        }

        public Teacher(List<TeacherSubjectGroup> teacherSubjectGroups, Guid id, PersonData personData,
            TeacherExpData teacherExpData, Guid departmentId) : this(id, personData, teacherExpData, departmentId)
        {
            CustomValidator.ValidateObject(teacherSubjectGroups);
            _teacherSubjectGroups = teacherSubjectGroups;
        }
    }
}