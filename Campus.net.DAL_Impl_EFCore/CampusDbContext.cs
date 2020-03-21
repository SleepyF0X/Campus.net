using Campus.net.DAL_Impl_EFCore.DbModels.AdditionalData;
using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using Campus.net.DAL_Impl_EFCore.DbModels.RelationClasses;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL_Impl_EFCore
{
    internal class CampusDbContext : IdentityDbContext
    {
        public DbSet<StudentDbModel> Students { get; set; }
        public DbSet<GroupDbModel> Groups { get; set; }
        public DbSet<TeacherDbModel> Teachers { get; set; }
        public DbSet<SubjectDbModel> Subjects { get; set; }
        public DbSet<FacultyDbModel> Faculties { get; set; }
        public DbSet<DepartmentDbModel> Departments { get; set; }
        public DbSet<SpecialtyDbModel> Specialties { get; set; }
        public DbSet<SpecializationDbModel> Specializations { get; set; }
        /////////////////////////////////////////////////////////////////
        public DbSet<TeacherSubjectDbModel> TeacherSubjects { get; set; }
        public DbSet<TeacherSubject_GroupDbModel> TeacherSubject_Groups { get; set; }
        //////////////////////////////////////////////////////////////////
        public DbSet<PersonDataDbModel> PersonDatas { get; set; }
        public DbSet<StudentDataDbModel> StudentDatas { get; set; }
        public DbSet<SubjectDataDbModel> SubjectDatas { get; set; }
        public DbSet<TeacherExpDataDbModel> TeacherExpDatas { get; set; }
    }
}
