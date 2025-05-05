using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace EnrollmentSystem.Models
{
    public class Applicant
    {


        [Key]
        public string? ApplicantID { get; set; }

        [Required(ErrorMessage ="Firstname is required")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "MiddleName is required")]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required")]
        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "DateOfBirth is required")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }

        [Required]
        public string? ApplicationStatus { get; set; }
       

        public ICollection<Document>? Documents { get; set; }
        public ICollection<ProgramEnrollment>? Enrollments { get; set; }
    }
}
