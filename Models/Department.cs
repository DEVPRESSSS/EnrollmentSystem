using System.ComponentModel.DataAnnotations;

namespace EnrollmentSystem.Models
{
    public class Department
    {

        [Key]
        public string? DepartmentID { get; set; }

        [Required]
        public string? DepartmentName { get; set; }

        [Required]
        public string? CourseCode { get; set; }

        public ICollection<Programs>? Programs { get; set; }
    }
}
