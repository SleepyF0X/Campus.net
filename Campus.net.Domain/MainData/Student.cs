using Campus.net.Domain.AdditionalData;
using Campus.net.Shared;
using System;

namespace Campus.net.Domain.MainData
{
    public class Student
    {
        public Guid Id { get; }
        public PersonData PersonData { get; }
        public StudentLearningData LearningData { get; }
        public Group Group { get; }

        public Student(Guid id, PersonData personData, StudentLearningData learningData, Group group)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateObject(personData);
            CustomValidator.ValidateObject(learningData);
            CustomValidator.ValidateObject(group);
            Id = id;
            PersonData = personData;
            LearningData = learningData;
            Group = group;
        }
    }
}