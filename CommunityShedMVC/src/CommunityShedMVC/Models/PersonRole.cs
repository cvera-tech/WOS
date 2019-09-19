using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityShedMVC.Models
{
    public class PersonRole
    {
        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoleName { get; set; }

        public string Name
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public override string ToString()
        {
            return $"{Name}: {RoleName}";
        }
    }
}