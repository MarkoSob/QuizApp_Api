using System.ComponentModel.DataAnnotations;

namespace QuizApp_DAL.Entities
{
    public class Quiz : Entity
    {
        [Required]
        [StringLength(140, MinimumLength = 1)]
        public string? Title { get; set; }
        [Required]
        public string? Description { get; set; }
        [Required]
        public ICollection<Question>? Questions { get; set; }
    }
}
