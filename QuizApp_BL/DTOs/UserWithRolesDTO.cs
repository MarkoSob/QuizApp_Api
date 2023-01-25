using QuizApp_DAL.Entities;

namespace QuizApp_BL.DTOs
{
    public class UserWithRolesDTO
    {
        public User? User { get; set; }
        public IEnumerable<string>? UserRoles { get; set; }
    }
}
