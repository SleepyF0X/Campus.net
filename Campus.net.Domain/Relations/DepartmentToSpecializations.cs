using System;
using System.Collections.Generic;
using System.Text;
using Campus.net.Domain.MainData;

namespace Campus.net.Domain.Relations
{
    public static class DepartmentToSpecializations
    {
        public static readonly Dictionary<Guid, Department> Departments = new Dictionary<Guid, Department>();
        public static readonly Dictionary<Guid, Specialization> Specializations = new Dictionary<Guid, Specialization>();
    }
}
