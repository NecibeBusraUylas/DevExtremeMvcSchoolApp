//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DevExtremeMvcSchoolApp.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SchoolAppDatabaseEntities : DbContext
    {
        public SchoolAppDatabaseEntities()
            : base("name=SchoolAppDatabaseEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<CourseEnrollment> CourseEnrollment { get; set; }
        public virtual DbSet<Instructor> Instructor { get; set; }
        public virtual DbSet<Student> Student { get; set; }
    }
}
