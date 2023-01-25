using AutoMapper;
using QuizApp_BL.DTOs;
using QuizApp_BL.Services.HashService;
using QuizApp_BL.Services.TokenService;
using QuizApp_Core.Exceptions;
using QuizApp_DAL.BasicGenericRepository;
using QuizApp_DAL.Entities;
using QuizApp_DAL.GenericRepository;
using QuizApp_DAL.RolesHelper;

namespace QuizApp_BL.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<User> _userRepository;
        private readonly IBasicGenericRepository<UserRoles> _userRolesRepository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IHashService _hashService;
        private readonly IRolesHelper _rolesHelper;
       
        public AuthService(
            IGenericRepository<User> userRepository,
            IBasicGenericRepository<UserRoles> userRolesRepository,
            IMapper mapper,
            ITokenService tokenService,
            IHashService hashService,
            IRolesHelper rolesHelper
            )
        {
            _userRepository = userRepository;
            _userRolesRepository = userRolesRepository;
            _mapper = mapper;
            _tokenService = tokenService;
            _hashService = hashService;
            _rolesHelper = rolesHelper;
        }

        public async Task RegisterAsync(RegistrationDTO registartionDTO)
        {
            var user = _mapper.Map<User>(registartionDTO);
            user.Password = _hashService.GetHash(user.Password!);
            user.Email = user.Email?.ToLower();

            var roleId = _rolesHelper[RolesList.User];

            await _userRepository.CreateAsync(user);

            await _userRolesRepository.CreateAsync(new UserRoles
            {
                UserId = user.Id,
                RoleId = roleId,
            });
        }

        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
            var userWithRolesDto = _userRepository
                .GetByPredicate(x => x.Email == loginDTO.Login!.ToLower())
                .Select(x => new UserWithRolesDTO
                {
                    User = x,
                    UserRoles = x.Roles!.Select(x => x.Role!.Title)!
                })
                .FirstOrDefault();

            if (userWithRolesDto != null)
            {
                if (_hashService.ValidateHash(loginDTO.Password!, userWithRolesDto.User.Password!))
                {
                    return _tokenService.GenerateToken(userWithRolesDto.User.Email!, userWithRolesDto.UserRoles);
                }
            }

            throw new ObjectNotFoundException(typeof(UserWithRolesDTO));
        }
    }
}
