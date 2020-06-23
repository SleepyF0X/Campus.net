﻿using Campus.net.Domain.Enums;
using Campus.net.Domain.MainData;
using Campus.net.Shared;
using System;

namespace Campus.net.DAL_Impl_EFCore.DbModels.AdditionalData
{
    internal sealed class StudentDataDbModel
    {
        public Guid Id { get; private set; }
        public Guid FacultyDbModelId { get; private set; }
        public Guid SpecializationDbModelId { get; private set; }
        public DateTimeOffset EntryDate { get; private set; }
        public StudyForm StudyForm { get; private set; }
        public StudyType StudyType { get; private set; }

        public StudentDataDbModel(Guid id, Guid facultyDbModelId, Guid specializationDbModelId, DateTimeOffset entryDate, StudyForm studyForm, StudyType studyType)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateId(specializationDbModelId);
            CustomValidator.ValidateId(facultyDbModelId);
            Id = id;
            FacultyDbModelId = facultyDbModelId;
            SpecializationDbModelId = specializationDbModelId;
            EntryDate = entryDate;
            StudyForm = studyForm;
            StudyType = studyType;
        }
    }
}