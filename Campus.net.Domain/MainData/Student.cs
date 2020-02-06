using Campus.net.Domain.AdditionalData;
using Campus.net.Shared;
using System;

namespace Campus.net.Domain.MainData
{
    public class Student
    {
        public Guid Id { get; }
        public PersonalInfo PersonalInfo { get; }
        public StudentLearningData LearningData { get; }
        public Group Group { get; }

        public Student(Guid id, PersonalInfo personalInfo, StudentLearningData learningData, Group group)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateObject(personalInfo);
            CustomValidator.ValidateObject(learningData);
            CustomValidator.ValidateObject(group);
            Id = id;
            PersonalInfo = personalInfo;
            LearningData = learningData;
            Group = group;
        }
    }
}