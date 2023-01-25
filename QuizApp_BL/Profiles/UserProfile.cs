using QuizApp_DAL.Entities;
using AutoMapper;
using QuizApp_BL.DTOs;

namespace QuizApp_BL.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegistrationDTO, User>();
        }
    }
}
