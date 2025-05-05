using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnrollmentSystem.Models
{
    public class Programs
    {
        [Key]
        public string? ProgramID { get; set; }

        [Required]
        public string? CourseCode { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Description { get; set; }

        [Required]
        public int Credits { get; set; }

        [Required]
        public string? DepartmentID { get; set; }

        [ForeignKey("DepartmentID")]
        public Department? Department { get; set; }
        public bool IsAvailableForEnrollment { get; set; }
        public int MaxCapacity { get; set; }
        public int CurrentEnrollment { get; set; }
        public ICollection<ProgramEnrollment>? Enrollments { get; set; }
    }
}
