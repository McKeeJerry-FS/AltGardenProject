using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AltGardenProject.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(100, ErrorMessage = "The {0} should be at least {2} characters and no more than {1} characters", MinimumLength = 2)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} should be at least {2} characters and no more than {1} characters", MinimumLength = 2)]
        public string? LastName { get; set; }
        [NotMapped]
        public string FullName { get { return FirstName + " " + LastName; } }

    }
}
