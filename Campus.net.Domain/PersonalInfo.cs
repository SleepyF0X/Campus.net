using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain
{
    public class PersonalInfo
    {
        public Guid Id { get; }
        public string Name { get; }
        public string Surname { get; }
        public string Patronymic { get; }
        public DateTimeOffset BirthDate { get; }
        public string Adress { get; } //проживания 
    }
}
