using System.ComponentModel.DataAnnotations;

namespace QuizApp_DAL.Entities
{
    public abstract class Entity
    {
        [Key]
        public Guid Id { get; set; }
    }
}
