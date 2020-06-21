using Campus.net.Shared;
using System;

namespace Campus.net.DAL_Impl_EFCore.DbModels.AdditionalData
{
    internal sealed class PersonDataDbModel
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Patronymic { get; private set; }
        public DateTimeOffset BirthDate { get; private set; }
        public string Address { get; private set; }

        public PersonDataDbModel(Guid id, string name, string surname, string patronymic, DateTimeOffset birthDate, string address)
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