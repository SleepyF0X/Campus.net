using Campus.net.Domain.MainData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.Relations
{
    public static class SpecialityToSpecializations
    {
        public static readonly Dictionary<Guid, Specialty> Speciality = new Dictionary<Guid, Specialty>();
        public static readonly Dictionary<Guid, Specialization> Specializations = new Dictionary<Guid, Specialization>();
    }
}
