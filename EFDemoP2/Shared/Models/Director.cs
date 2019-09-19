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

        public Director() { }

        public Director(string name)
        {
            Name = name;
            Movies = new List<Movie>();
        }
    }
}
