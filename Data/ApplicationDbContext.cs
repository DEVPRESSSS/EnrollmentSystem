using EnrollmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace EnrollmentSystem.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Programs> Programs  { get; set; }
        public DbSet<ProgramEnrollment> ProgramEnrollment { get; set; }


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


            modelBuilder.Entity<Applicant>().HasData(

                new Applicant
                {
                    ApplicantID = "Applicant01",
                    FirstName = "Jerald",
                    MiddleName = "Rabino",
                    LastName = "Montemor",
                    Email = "montemorjeraldd@gmail.com",
                    DateOfBirth = new DateTime(2000, 5, 15),
                    Address = "Malabon City",
                    PhoneNumber = "09488749263",
                    ApplicationStatus = "Pending",
                },
                new Applicant
                {
                    ApplicantID = "Applicant02",
                    FirstName = "Anna",
                    MiddleName = "Marie",
                    LastName = "Lopez",
                    Email = "anna.lopez@example.com",
                    DateOfBirth = new DateTime(2000, 5, 15),
                    Address = "Quezon City",
                    PhoneNumber = "09488749263",
                    ApplicationStatus = "Approved",
                },
                new Applicant
                {
                    ApplicantID = "Applicant03",
                    FirstName = "Mark",
                    MiddleName = "Anthony",
                    LastName = "Cruz",
                    Email = "mark.cruz@example.com",
                    DateOfBirth = new DateTime(1999, 10, 30),
                    Address = "Caloocan City",
                    PhoneNumber = "09488749263",
                    ApplicationStatus = "Pending",
                },
                new Applicant
                {
                    ApplicantID = "Applicant04",
                    FirstName = "Sophia",
                    MiddleName = "Grace",
                    LastName = "Del Rosario",
                    Email = "sophia.delrosario@example.com",
                    DateOfBirth = new DateTime(2001, 3, 20),
                    Address = "Makati City",
                    PhoneNumber ="09488749263",
                    ApplicationStatus = "Rejected",
                },
                new Applicant
                {
                    ApplicantID = "Applicant05",
                    FirstName = "John",
                    MiddleName = "Paul",
                    LastName = "Santos",
                    Email = "john.santos@example.com",
                    DateOfBirth = new DateTime(1998, 12, 12),
                    Address = "Pasig City",
                    PhoneNumber = "09488749263",
                    ApplicationStatus = "Pending",
                }


             ); 



        }

    }
}
