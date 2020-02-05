using Campus.net.Domain.AdditionalData;
using System;
using System.Collections.Generic;
using System.Text;
using Campus.net.Shared;

namespace Campus.net.Domain.MainData
{
    public class Teacher
    {
        public Guid Id { get; }
        public PersonalInfo PersonalInfo { get; }
        public TeacherLearningData TeacherLearningData { get; }
        public TeacherExpData TeacherExpData { get; } 

        public Teacher(Guid id, PersonalInfo personalInfo, TeacherLearningData teacherLearningData, TeacherExpData teacherExpData)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateObject(personalInfo);
            CustomValidator.ValidateObject(teacherLearningData);
            CustomValidator.ValidateObject(teacherExpData);
            Id = id;
            PersonalInfo = personalInfo;
            TeacherLearningData = teacherLearningData;
            TeacherExpData = teacherExpData;
        }
    }
}
