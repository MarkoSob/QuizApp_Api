using Microsoft.Extensions.Logging;

namespace QuizApp_Core.Extensions
{
    public static class ILoggerExtensions
    {
        public static void LogMessageAndThrowException(this ILogger logger, string message, Exception exception)
        {
            logger?.LogError(exception, message);
            throw exception;
        }
    }
}
