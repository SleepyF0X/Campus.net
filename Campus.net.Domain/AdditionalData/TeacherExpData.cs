using Campus.net.Shared;
using System;

namespace Campus.net.Domain.AdditionalData
{
    public sealed class TeacherExpData
    {
        public Guid Id { get; }
        public double Rating { get; }
        public string Position { get; } //должность {зав кафедры/ старший преподователь/ ассистент...}
        public int Experience { get; } //стаж препода в годах

        public TeacherExpData(Guid id, double rating, string position, int experience)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateNumber(rating, 0, 5);
            CustomValidator.ValidateString(position, 2, 30);
            CustomValidator.ValidateNumber(experience, 0, 70);
            Id = id;
            Rating = rating;
            Position = position;
            Experience = experience;
        }
    }
}