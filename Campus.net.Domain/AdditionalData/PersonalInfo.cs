using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.AdditionalData
{
    public class PersonalInfo
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Patronymic { get; }
        public DateTimeOffset BirthDate { get; }
        public string Adress { get; } //проживания 

        public PersonalInfo(Guid id, string name, string surname, string patronymic, DateTimeOffset birthDate, string adress)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            BirthDate = birthDate;
            Adress = adress;
        }
    }
}
