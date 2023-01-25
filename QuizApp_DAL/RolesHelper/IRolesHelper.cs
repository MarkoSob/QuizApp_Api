
namespace QuizApp_DAL.RolesHelper
{
    public interface IRolesHelper
    {
        Guid this[string roleTitle] { get; }
    }
}