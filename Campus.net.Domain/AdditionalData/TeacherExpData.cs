using Campus.net.Shared;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.AdditionalData
{
    public class TeacherExpData
    {
        public Guid Id { get; }
        public double Raiting { get; }
        public string Position { get; } //должность {зав кафедры/ старший преподователь/ ассистент...}
        public int Expirience { get; } //стаж препода в годах

        public TeacherExpData(Guid id, double raiting, string position, int expirience)
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
