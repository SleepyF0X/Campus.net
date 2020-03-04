using Campus.net.Shared;
using System;

namespace Campus.net.DAL_Impl_EFCore.DbModels.AdditionalData
{
    public class TeacherExpDataDbModel
    {
        public Guid Id { get; private set; }
        public double Raiting { get; private set; }
        public string Position { get; private set; } //должность {зав кафедры/ старший преподователь/ ассистент...}
        public int Expirience { get; private set; } //стаж препода в годах

        public TeacherExpDataDbModel(Guid id, double raiting, string position, int expirience)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateNumber(raiting, 0, 5);
            CustomValidator.ValidateString(position, 2, 30);
            CustomValidator.ValidateNumber(expirience, 0, 70);
            Id = id;
            Raiting = raiting;
            Position = position;
            Expirience = expirience;
        }
    }
}