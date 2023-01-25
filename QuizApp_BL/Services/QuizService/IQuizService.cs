using QuizApp_BL.DTOs;
using QuizApp_DAL.Entities;

namespace QuizApp_BL.Services.QuizService
{
    public interface IQuizService
    {
        Task<IEnumerable<Quiz>> GetAllQuizzesAsync();
        Task<IEnumerable<Quiz>> GetRandomNumberOfQuizzesAsync(int numberOfQuizzes);
        Task<IEnumerable<QuestionForUserDTO>> GetAllQuizQuestionsAsync(Guid quizId);
        Task<IEnumerable<Choice>> GetAllQuestionChoicesAsync(Guid questionId);
        Task<int> CheckQuizAnswers(IDictionary<Guid, string> userAnswers);
    }
}