using Campus.net.Domain.MainData;
using System;

namespace Campus.net.Domain.AdditionalData
{
    public sealed class SubjectData
    {
        public Guid Id { get; }
        public Subject Subject { get; }

        public Specialization Specialization { get; }
        //Fuck this shit
        //Часы, кредиты, прочая шняга, позже
    }
}