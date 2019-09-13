using CommunityShedMVC.Models;
using System;
using System.Security.Principal;

namespace CommunityShedMVC.Security
{
    public class CustomPrincipal : IPrincipal
    {
        private CustomIdentity identity;
        public Person Person { get; private set; }

        public CustomPrincipal(CustomIdentity identity, Person person)
        {
            this.identity = identity;
            Person = person;
        }

        public IIdentity Identity
        {
            get
            {
                return identity;
            }
        }

        public bool IsInRole(string role)
        {
            throw new NotImplementedException();
        }

        public bool IsInRole(string role, int communityId)
        {
            return Person.Roles.Exists(r => (r.CommunityId == communityId && r.RoleName == role));
        }

        public bool CanEditCommunity(int communityId)
        {
            // Since there is no super user role, just check if
            // the user has all the avaiable roles.
            return IsInRole("Approver", communityId) &&
                   IsInRole("Reviewer", communityId) &&
                   IsInRole("Enforcer", communityId);
        }
    }
}