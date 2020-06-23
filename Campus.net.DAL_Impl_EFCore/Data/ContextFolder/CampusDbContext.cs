using Campus.net.DAL_Impl_EFCore.Data.Identity;
using Campus.net.DAL_Impl_EFCore.DbModels.AdditionalData;
using Campus.net.DAL_Impl_EFCore.DbModels.MainData;
using Campus.net.DAL_Impl_EFCore.DbModels.RelationClasses;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Campus.net.DAL_Impl_EFCore.Data.ContextFolder
{
    public class CampusDbContext : IdentityDbContext<ApplicationUser>
    {
        public CampusDbContext(DbContextOptions options) : base(options)
        {
            
        }

        internal DbSet<StudentDbModel> Students { get; set; }
        internal DbSet<GroupDbModel> Groups { get; set; }
        internal DbSet<TeacherDbModel> Teachers { get; set; }
        internal DbSet<SubjectDbModel> Subjects { get; set; }
        internal DbSet<FacultyDbModel> Faculties { get; set; }
        internal DbSet<DepartmentDbModel> Departments { get; set; }
        internal DbSet<SpecialtyDbModel> Specialties { get; set; }
        internal DbSet<SpecializationDbModel> Specializations { get; set; }
        /////////////////////////////////////////////////////////////////
        internal DbSet<TeacherSubjectDbModel> TeacherSubjects { get; set; }
        internal DbSet<TeacherSubject_GroupDbModel> TeacherSubject_Groups { get; set; }
        //////////////////////////////////////////////////////////////////
        internal DbSet<PersonDataDbModel> PersonDatas { get; set; }
        internal DbSet<StudentDataDbModel> StudentDatas { get; set; }
        internal DbSet<SubjectDataDbModel> SubjectDatas { get; set; }
        internal DbSet<TeacherExpDataDbModel> TeacherExpDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
