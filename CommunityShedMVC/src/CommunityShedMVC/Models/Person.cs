using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CommunityShedMVC.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; } 

        [Required]
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Password")]
        public string HashedPassword { get; set; }

        public List<CommunityRole> Roles { get; set; }
        public string Name { get { return $"{FirstName} {LastName}"; } }

        public override string ToString()
        {
            return $"{FirstName} {LastName}({EmailAddress})";
        }

        public List<CommunityRole> GetRolesInCommunity(int communityId)
        {
            return Roles.FindAll(c => c.CommunityId == communityId);
        }
    }
}