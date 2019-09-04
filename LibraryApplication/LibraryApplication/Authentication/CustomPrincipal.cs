using System.Linq;
using System.Security.Principal;

namespace LibraryApplication.Authentication
{
    public class CustomPrincipal : IPrincipal
    {
        private CustomIdentity identity;
        private string[] roles;

        public CustomPrincipal(CustomIdentity identity, string[] roles)
        {
            this.identity = identity;
            this.roles = roles;
        }

        public IIdentity Identity
        {
            get
            {
                return identity;
            }
        }

        public CustomIdentity CustomIdentity
        {
            get
            {
                return identity;
            }
        }

        public bool IsInRole(string role)
        {
            return roles.Contains<string>(role);
        }
    }
}