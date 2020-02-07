using Campus.net.Shared;
using System;

namespace Campus.net.Domain.AdditionalData.FacultyData
{
    public class FacultyContactData
    {
        public Guid Id { get; }
        public string PhoneNumber { get; }
        public string Adress { get; }

        //можно добавить что-то еще
        public FacultyContactData(Guid id, string phoneNumber, string adress)
        {
            CustomValidator.ValidateId(id);
            CustomValidator.ValidateString(phoneNumber, 7, 13); // городской 7 (236-19-70), мобильный 12 (380991644096) и еще плюсик, потому 13
            CustomValidator.ValidateString(adress, 3, 60);
            Id = id;
            PhoneNumber = phoneNumber;
            Adress = adress;
        }
    }
}