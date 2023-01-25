using System.Net;

namespace QuizApp_Core.Exceptions
{
    public class ObjectNotFoundException : HttpResponseException
    {
        public ObjectNotFoundException(Type objectType) : base(HttpStatusCode.NotFound, $"Object of type {objectType} not found")
        {

        }
    }
}
