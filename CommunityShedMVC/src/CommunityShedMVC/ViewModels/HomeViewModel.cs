using CommunityShedMVC.Models;
using System.Collections.Generic;
using System.Text;

namespace CommunityShedMVC.ViewModels
{
    public class HomeViewModel
    {
        public List<Item> BorrowedItems { get; set; }
        public List<Item> UserItems { get; set; }
        public List<Community> Communities { get; set; }
        public List<CommunityRole> CommunityRoles { get; set; }

        /// <summary>
        /// This method returns a string containing all the user's roles for a 
        /// given community.
        /// </summary>
        /// <param name="community">The community to check.</param>
        /// <returns>A string with all the person's roles.</returns>
        public string Roles(Community community)
        {
            StringBuilder rolesStringBuilder = new StringBuilder();
            List<CommunityRole> roles = CommunityRoles.FindAll(cr => cr.CommunityId == community.Id);
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