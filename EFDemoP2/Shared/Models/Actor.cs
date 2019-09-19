using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Name { get; set; }

        public List<Movie> Movies { get; set; }

        public Actor()
        {
            Movies = new List<Movie>();
        }

        public Actor(string name)
        {
            Name = name;
        }
    }
}
