using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Models
{
    class Person
    {
        // Id, ID, PersonId, PersonID
        // Automatically set as primary key and 
        // identity column if `int` or `guid`
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public decimal Weight { get; set; }
        public bool IsStarWarsFan { get; set; }

        public string Info
        {
            get
            {
                return $"{Name} ({BirthDate}";
            }
        }

    }
}
