using System.ComponentModel.DataAnnotations;

namespace QuizApp_BL.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string? Login { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
