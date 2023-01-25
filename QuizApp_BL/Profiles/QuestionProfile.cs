using QuizApp_DAL.Entities;
using AutoMapper;
using QuizApp_BL.DTOs;

namespace QuizApp_BL.Profiles
{
    public class QuestionProfile : Profile
    {
        public QuestionProfile()
        {
            CreateMap<Question, QuestionForUserDTO>();
        }
    }
}