using Campus.net.Domain.MainData;
using System;

namespace Campus.net.Domain.AdditionalData
{
    public class SubjectData
    {
        public Guid Id { get; private set; }
        public Subject Subject { get; private set; }
        public Specialization Specialization { get; private set; }
        //Fuck this shit
        //Часы, кредиты, прочая шняга, позже
    }
}