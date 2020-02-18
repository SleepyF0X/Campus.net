using Campus.net.Shared;
using System;

namespace Campus.net.Domain.AdditionalData
{
    public class PersonData
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Patronymic { get; }
        public DateTimeOffset BirthDate { get; }
        public string Address { get; }

        public PersonData(Guid id, string name, string surname, string patronymic, DateTimeOffset birthDate, string address)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(name, 2, 20);
            CustomValidator.ValidateString(surname, 2, 20);
            CustomValidator.ValidateString(patronymic, 2, 20);
            CustomValidator.ValidateString(address, 1, 80);
            Id = id;
            Name = name;
            Surname = surname;
            Patronymic = patronymic;
            BirthDate = birthDate;
            Address = address;
        }
    }
}