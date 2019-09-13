using CommunityShedMVC.Models;
using System.Collections.Generic;

namespace CommunityShedMVC.ViewModels
{
    public class CommunityDetailsViewModel
    {
        public Community Community { get; set; }
        public List<PersonRole> PersonRoles { get; set; }
        public List<Person> Members { get; set; }
        public bool CanEdit { get; set; }
        public bool CanEditMembers { get; set; }

        /// <summary>
        /// This method returns a string containing all the roles of a community member.
        /// </summary>
        /// <param name="personId">The Id of the person.</param>
        /// <returns>A string with all the person's roles.</returns>
        public string BuildRolesString(int personId)
        {
            List<PersonRole> roles = PersonRoles.FindAll(pr => pr.PersonId == personId);
            List<string> roleNames = new List<string>();
            foreach (var pr in roles)
            {
                roleNames.Add(pr.RoleName);
            }
            return string.Join(", ", roleNames);
        }
    }
}