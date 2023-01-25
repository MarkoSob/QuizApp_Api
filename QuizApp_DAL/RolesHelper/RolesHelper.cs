using QuizApp_DAL.Entities;

namespace QuizApp_DAL.RolesHelper
{
    public class RolesHelper : IRolesHelper
    {
        private Dictionary<string, Guid> _roles;

        public RolesHelper()
        {
            _roles = new Dictionary<string, Guid>()
            {
                { RolesList.Admin, Guid.Parse("c86deec2-7efa-4c13-a4ea-7614c37945d2") },
                { RolesList.User, Guid.Parse("6690193a-3dbc-416c-8a20-9751b4c48f57") }
            };
        }

        public Guid this[string roleTitle]
            => _roles[roleTitle];
    }
}