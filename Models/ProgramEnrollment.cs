using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentSystem.Models
{
    public class ProgramEnrollment
    {
        [Key]
        public string? ProgramEnrollmentID { get; set; }

        public string? ApplicantID { get; set; }

        [ForeignKey("ApplicantID")]
        public Applicant? Applicant { get; set; }

        public string? ProgramID { get; set; }
        [ForeignKey("ProgramID")]
        public Programs? Program { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public string? Status { get; set; } 
    }
}
