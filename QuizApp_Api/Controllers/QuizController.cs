using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuizApp_BL.Services.QuizService;

namespace QuizApp_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;

        public QuizController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuizzesAsync()
        {
            var result = await _quizService.GetAllQuizzesAsync();
            return Ok(result);
        }

        [HttpGet("quizzes")]
        public async Task<IActionResult> GetRandomNumberOfQuizzesAsync(int numberOfQuizzes)
        {
            var result = await _quizService.GetRandomNumberOfQuizzesAsync(numberOfQuizzes);
            return Ok(result);
        }

        [HttpGet("{quizId}")]
        public async Task<IActionResult> GetAllQuestionsAsync(Guid quizId)
        {
            var result = await _quizService.GetAllQuizQuestionsAsync(quizId);
            return Ok(result);
        }

        [HttpGet("question/{questionId}")]
        public async Task<IActionResult> GetAllChoicesAsync(Guid questionId)
        {
            var result = await _quizService.GetAllQuestionChoicesAsync(questionId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> GetQuizScoreAsync(IDictionary<Guid, string> userAnswers)
        {
            var result = await _quizService.CheckQuizAnswers(userAnswers);
            return Ok(result);
        }
    }
}
