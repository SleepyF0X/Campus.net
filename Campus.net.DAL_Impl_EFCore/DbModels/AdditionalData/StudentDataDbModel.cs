using Campus.net.Domain.Enums;
using Campus.net.Domain.MainData;
using Campus.net.Shared;
using System;

namespace Campus.net.DAL_Impl_EFCore.DbModels.AdditionalData
{
    internal class StudentDataDbModel
    {
        public Guid Id { get; private set; }
        public Guid SpecializationDbModelId { get; private set; }
        public int Course { get; private set; }
        public DateTimeOffset EntryDate { get; private set; }
        public StudyForm StudyForm { get; private set; }
        public StudyType StudyType { get; private set; }

        public StudentDataDbModel(Guid id, Guid specializationDbModelId, DateTimeOffset entryDate, StudyForm studyForm, StudyType studyType)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateId(specializationDbModelId);
            Id = id;
            SpecializationDbModelId = specializationDbModelId;
            EntryDate = entryDate;
            StudyForm = studyForm;
            StudyType = studyType;
        }
    }
}