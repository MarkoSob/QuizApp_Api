using System.Security.Claims;

namespace QuizApp_BL.Services.TokenService
{
    public interface ITokenService
    {
        string GenerateToken(string userName, IEnumerable<string> userRoles);
    }
}