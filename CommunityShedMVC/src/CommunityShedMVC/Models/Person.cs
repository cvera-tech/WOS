using System.Collections.Generic;

namespace CommunityShedMVC.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string EmailAddress { get; set; }
        public string HashedPassword { get; set; }
        public List<CommunityRole> Roles { get; set; }
        public string Name { get { return $"{FirstName} {LastName}"; } }

        public override string ToString()
        {
            return $"{FirstName} {LastName}({EmailAddress})";
        }
    }
}