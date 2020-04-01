using Campus.net.Domain.AdditionalData;
using Campus.net.Domain.RelationClasses;
using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Campus.net.Domain.MainData
{
    public sealed class Group
    {
        public Guid Id { get; }
        public string GroupName { get; }
        public Guid SpecializationId { get; }
        private readonly List<Student> _students;
        public IReadOnlyCollection<Student> Students => _students.AsReadOnly();
        private readonly List<TeacherSubjectGroup> _teacherSubjectGroups;

        public IReadOnlyCollection<TeacherSubject> TeacherSubjects => 
            (from tsg in _teacherSubjectGroups
            where tsg.TeacherId.Equals(Id)
            select new TeacherSubject(tsg.TeacherId, tsg.SubjectId)).ToList().AsReadOnly();

        public Group(Guid id, string groupName, Guid specializationId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(groupName, 5, 5);
            CustomValidator.ValidateId(specializationId);
            Id = id;
            GroupName = groupName;
            SpecializationId = specializationId;
            _students = new List<Student>();
            _teacherSubjectGroups = new List<TeacherSubjectGroup>();
        }

        public Group(List<Student> students, List<TeacherSubjectGroup> teacherSubjectGroups, Guid id, string groupName,
            Guid specializationId) : this(id, groupName, specializationId)
        {
            CustomValidator.ValidateObject(teacherSubjectGroups);
            CustomValidator.ValidateObject(students);
            _students = students;
            _teacherSubjectGroups = teacherSubjectGroups;
        }
    }
}