using Campus.net.Shared;
using System;

namespace Campus.net.DAL_Impl_EFCore.DbModels.AdditionalData
{
    internal sealed class TeacherExpDataDbModel
    {
        public Guid Id { get; private set; }
        public double Rating { get; private set; }
        public string Position { get; private set; } //должность {зав кафедры/ старший преподователь/ ассистент...}
        public int Experience { get; private set; } //стаж препода в годах

        public TeacherExpDataDbModel(Guid id, double rating, string position, int experience)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateNumber(rating, 0, 5);
            CustomValidator.ValidateString(position, 2, 30);
            CustomValidator.ValidateNumber(experience, 0, 70);
            Id = id;
            Rating = rating;
            Position = position;
            Experience = Experience;
        }
    }
}