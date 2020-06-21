using Campus.net.DAL_Impl_EFCore.DbModels.AdditionalData;
using Campus.net.DAL_Impl_EFCore.Mappers.Interfaces.AdditionalData;
using Campus.net.Domain.AdditionalData;

namespace Campus.net.DAL_Impl_EFCore.Mappers.Implementation.AdditionalData
{
    internal sealed class PersonDataMapper : IPersonDataMapper
    {
        public PersonDataDbModel DomainToDb(PersonData item)
        {
            return new PersonDataDbModel(item.Id, item.Name, item.Surname, item.Patronymic, item.BirthDate, item.Address);
        }

        public PersonData DbToDomain(PersonDataDbModel item)
        {
            return new PersonData(item.Id, item.Name, item.Surname, item.Patronymic, item.BirthDate, item.Address);
        }
    }
}
