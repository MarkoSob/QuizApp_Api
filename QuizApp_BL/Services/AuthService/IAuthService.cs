using QuizApp_BL.DTOs;

namespace QuizApp_BL.Services.AuthService
{
    public interface IAuthService
    {
        Task<string> LoginAsync(LoginDTO loginDTO);
        Task RegisterAsync(RegistrationDTO registartionDTO);
    }
}