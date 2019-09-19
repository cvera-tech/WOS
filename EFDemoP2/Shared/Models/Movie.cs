using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Shared.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required, MaxLength(255)]
        public string Title { get; set; }

        // Foreign Key property
        public int DirectorId { get; set; }
        // Navigation property
        public Director Director { get; set; }

        public List<Actor> Actors { get; set; }

        public Movie()
        {
            Actors = new List<Actor>();
        }

        public Movie(string title, Director director) : this()
        {
            Title = title;
        }
    }
}
