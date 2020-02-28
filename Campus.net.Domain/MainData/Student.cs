using Campus.net.Domain.AdditionalData;
using Campus.net.Shared;
using System;

namespace Campus.net.Domain.MainData
{
    public class Student
    {
        public Guid Id { get; private set; }
        public PersonData PersonData { get; private set; }
        public StudentData StudentData { get; private set; }
        public Group Group { get; private set; }
        public Guid GroupId { get; private set; }
        public Student(Guid id, PersonData personData, StudentData studentData, Guid groupId)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateObject(personData);
            CustomValidator.ValidateObject(studentData);
            CustomValidator.ValidateId(groupId);
            Id = id;
            PersonData = personData;
            StudentData = studentData;
            GroupId = groupId;
        }
    }
}