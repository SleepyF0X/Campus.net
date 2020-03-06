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
        public Student(Guid id, PersonData personData, StudentData studentData, Group group)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateObject(personData);
            CustomValidator.ValidateObject(studentData);
            CustomValidator.ValidateObject(group);
            Id = id;
            PersonData = personData;
            StudentData = studentData;
            Group = group;
        }
    }
}