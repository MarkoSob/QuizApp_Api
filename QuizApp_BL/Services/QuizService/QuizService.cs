using AutoMapper;
using Microsoft.EntityFrameworkCore;
using QuizApp_BL.DTOs;
using QuizApp_DAL.Entities;
using QuizApp_DAL.GenericRepository;

namespace QuizApp_BL.Services.QuizService
{
    public class QuizService : IQuizService
    {
        private readonly IGenericRepository<Quiz> _quizRepository;
        private readonly IGenericRepository<Question> _questionRepository;
        private readonly IGenericRepository<Choice> _choiceRepository;
        private readonly IMapper _mapper;

        public QuizService(IGenericRepository<Quiz> quizRepository,
            IGenericRepository<Question> questionRepository,
            IGenericRepository<Choice> choiceRepository,
            IMapper mapper)
        {
            _quizRepository = quizRepository;
            _questionRepository = questionRepository;
            _choiceRepository = choiceRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Quiz>> GetAllQuizzesAsync() =>
            await _quizRepository.GetAllAsync();

        public async Task<IEnumerable<Quiz>> GetRandomNumberOfQuizzesAsync(int numberOfQuizzes)
        {
            var listOfQuizzes = await _quizRepository.GetAllAsync();

            Random random = new Random();

            List<Quiz> selectedRandomQuizzes = listOfQuizzes.OrderBy(x => random.Next()).Take(numberOfQuizzes).ToList();

            return selectedRandomQuizzes;
        }


        public async Task<IEnumerable<QuestionForUserDTO>> GetAllQuizQuestionsAsync(Guid quizId)
        {
            var questions = await _questionRepository.GetByPredicate(q => q.QuizId == quizId).ToListAsync();

            return _mapper.Map<IEnumerable<QuestionForUserDTO>>(questions);
        }

        public async Task<IEnumerable<Choice>> GetAllQuestionChoicesAsync(Guid questionId) =>
            await _choiceRepository.GetByPredicate(q => q.QuestionId == questionId).ToListAsync();


        public async Task<int> CheckQuizAnswers(IDictionary<Guid, string> userAnswers)
        {
            int score = 0;

            foreach (var answer in userAnswers)
            {
                var question = await _questionRepository
                    .GetByPredicate(q => q.Id == answer.Key)
                    .FirstOrDefaultAsync();

                if (answer.Value.Equals(question?.CorrectAnswer, StringComparison.OrdinalIgnoreCase))
                {
                    score++;
                }
            }

            return score;
        }
    }
}
