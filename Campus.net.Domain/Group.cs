﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.Domain
{
    public class Group
    {
        public Guid Id { get; }
        private List<Student> _students;
        private List<Subject> _subjects;
        public IReadOnlyCollection<Student> Students => _students.AsReadOnly();
        public IReadOnlyCollection<Subject> Subjects => _subjects.AsReadOnly();
        public GroupName GroupName { get; }

    }
}
