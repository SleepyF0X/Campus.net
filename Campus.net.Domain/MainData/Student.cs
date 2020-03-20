using Campus.net.Domain.AdditionalData;
using Campus.net.Shared;
using System;

namespace Campus.net.Domain.MainData
{
    public sealed class Student
    {
        public Guid Id { get; }
        public PersonData PersonData { get; }
        public StudentData StudentData { get; }
        public Guid GroupId { get; }

        public Student(Guid id, PersonData personData, StudentData studentData, Guid groupId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateObject(personData);
            CustomValidator.ValidateObject(studentData);
            CustomValidator.ValidateObject(groupId);
            Id = id;
            PersonData = personData;
            StudentData = studentData;
            GroupId = groupId;
        }
    }
}