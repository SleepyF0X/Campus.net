using System;
using System.Collections.Generic;
using System.Text;
using Campus.net.DAL_Impl_EFCore.DbModels.AdditionalData;
using Campus.net.Domain.AdditionalData;
using Campus.net.Shared;

namespace Campus.net.DAL_Impl_EFCore.Mappers
{
    internal sealed class PersonDataMapper : IMapper<PersonData, PersonDataDbModel>
    {
        public PersonDataDbModel EntityToModel(PersonData item)
        {
            CustomValidator.ValidateObject(item);
            return new PersonDataDbModel(item.Id, item.Name, item.Surname, item.Patronymic, item.BirthDate, item.Address);
        }

        public PersonData ModelToEntity(PersonDataDbModel item)
        {
            CustomValidator.ValidateObject(item);
            return new PersonData(item.Id, item.Name, item.Surname, item.Patronymic, item.BirthDate, item.Address);
        }
    }
}
