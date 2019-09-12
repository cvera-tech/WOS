using CommunityShedMVC.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommunityShedMVC.ViewModels
{
    public class CommunityDetailsViewModel
    {
        public Community Community { get; set; }
        public List<PersonRole> PersonRoles { get; set; }
        public List<Person> Members { get; set; }

        /// <summary>
        /// This method returns a string containing all the roles of a community member.
        /// </summary>
        /// <param name="personId">The Id of the person.</param>
        /// <returns>A string with all the person's roles.</returns>
        public string BuildRolesString(int personId)
        {
            StringBuilder rolesStringBuilder = new StringBuilder();
            List<PersonRole> roles = PersonRoles.FindAll(pr => pr.PersonId == personId);
            foreach (var role in roles)
            {
                if (rolesStringBuilder.Length != 0)
                {
                    rolesStringBuilder.Append(", ");
                }
                rolesStringBuilder.Append(role.RoleName);
            }
            return rolesStringBuilder.ToString();
        }
    }
}