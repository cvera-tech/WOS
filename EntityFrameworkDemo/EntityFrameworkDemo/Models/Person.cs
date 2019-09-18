using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Models
{
    internal class Person
    {
        // Id, ID, PersonId, PersonID
        // Automatically set as primary key and 
        // identity column if `int` or `guid`
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Weight { get; set; }
        public bool IsStarWarsFan { get; set; }

        public string Info
        {
            get
            {
                return $"{Name} ({BirthDate}";
            }
        }

        public override string ToString()
        {
            return $"Name: {Name}\nBirthDate: {BirthDate.ToShortDateString()}\nWeight: {Weight}\nIsStarWarsFan: {IsStarWarsFan}";
        }
    }
}
