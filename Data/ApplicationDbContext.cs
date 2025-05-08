using EnrollmentSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentSystem.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Programs> Programs  { get; set; }
        public DbSet<ProgramEnrollment> ProgramEnrollment { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

                modelBuilder.Entity<Department>().HasData(

                     new Department { DepartmentID = "DEPARMENT001",
                         DepartmentName = "College of Technology", 
                         CourseCode = "TEST" },

                     new Department { DepartmentID = "DEPARMENT002", 
                         DepartmentName = "College of Engineering",
                         CourseCode = "TEST" }

            );


           



        }

    }
}
