using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentSystem.Models
{
    public class Document
    {

        [Key]
        public string? DocumentID { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? FilePath { get; set; }
        public string? FileType { get; set; }
        public DateTime UploadDate { get; set; }
        public string? DocumentStatus { get; set; }

        [ForeignKey(nameof(ApplicantID))]
        public string? ApplicantID { get; set; }
        public Applicant? Applicants { get; set; }
    }
}
