using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommunityShedMVC.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 
        public string EmailAddress { get; set; }
        public string HashedPassword { get; set; }
    }
}