using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Director
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }
        //
        public List<Movie> Movies { get; set; }

        public Director()
        {
            Movies = new List<Movie>();
        }

        public Director(string name) : this()
        {
            Name = name;
        }
    }
}
