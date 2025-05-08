using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentSystem.Models
{
    public class ApplicationUser:IdentityUser
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }

        public string? ApplicationStatus { get; set; }
    }
}
