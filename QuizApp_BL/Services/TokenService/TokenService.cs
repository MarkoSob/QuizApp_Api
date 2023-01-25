using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using QuizApp_BL.Options;

namespace QuizApp_BL.Services.TokenService
{
    public class TokenService : ITokenService
    {
        private readonly AuthOptions _authOptions;

        public TokenService(IOptions<AuthOptions> authOptions)
        {
            _authOptions = authOptions.Value;
        }
        public string GenerateToken(string userName, IEnumerable<string> userRoles)
        {
            var claims = userRoles
                .Select(r => new Claim(ClaimTypes.Role, r))
                .Append(new Claim(ClaimTypes.Name, userName));

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(60),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_authOptions.Key!)), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            JwtSecurityToken token = handler.CreateJwtSecurityToken(tokenDescriptor);

            return handler.WriteToken(token);
        }
    }
}

