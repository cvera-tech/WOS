using Shared.Models;
using System.Data.Entity;

namespace Shared.Data
{
    public class Context : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
    }
}
