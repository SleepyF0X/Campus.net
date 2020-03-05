using Campus.net.Domain.MainData;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain.Relations
{
    public static class FacultyToDepartments
    {
        public static readonly Dictionary<Guid, Department> Departments = new Dictionary<Guid, Department>();
        public static readonly Dictionary<Guid, Faculty> Faculties = new Dictionary<Guid, Faculty>();
    }
}
