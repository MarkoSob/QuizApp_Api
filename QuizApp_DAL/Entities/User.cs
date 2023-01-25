using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace QuizApp_DAL.Entities
{
    [Index(nameof(Email), IsUnique = true)]
    public class User : Entity
    {
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public ICollection<UserRoles>? Roles { get; set; }
    }
}
