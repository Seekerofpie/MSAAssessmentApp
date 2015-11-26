using MSAAssessmentApp.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MySql.Data.Entity;
using System.Data.Entity.Migrations;
using System.Collections.Generic;
using System;
using System.Linq;

namespace MSAAssessmentApp.DAL
{
    //[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class SchoolContext : DbContext
    {

        public SchoolContext() : base("name=SchoolContext")
        {
            if (!Database.Exists("SchoolContext"))
            {
                Database.SetInitializer(new MigrateDatabaseToLatestVersion<SchoolContext, Migrations.SchoolConfiguration>());
            }
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
    }
}