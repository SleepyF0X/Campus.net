using System;
using System.Collections.Generic;
using System.Text;
using Campus.net.Domain.MainData;

namespace Campus.net.Domain.Relations
{
    public static class SpecializationToGroups
    {
        public static readonly Dictionary<Guid, Specialization> Specializations = new Dictionary<Guid, Specialization>();
        public static readonly Dictionary<Guid, Group> Groups = new Dictionary<Guid, Group>();
    }
}
