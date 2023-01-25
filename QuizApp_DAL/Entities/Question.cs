using System.ComponentModel.DataAnnotations;

namespace QuizApp_DAL.Entities
{
    public class Question : Entity
    {
        [Required]
        public string? QuestionText { get; set; }
        [Required]
        public ICollection<Choice>? Choices { get; set; }
        [Required]
        public string? CorrectAnswer { get; set; }
        public Guid QuizId { get; set; }
        public Quiz? Quiz { get; set; }
    }
}
