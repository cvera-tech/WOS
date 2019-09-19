using Shared.Models;
using System.Data.Entity;

namespace Shared.Data
{
    public class Context : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Actor> Actors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Explicitly declare bridge table
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Actors)
                .WithMany(a => a.Movies)
                .Map(ma =>
                {
                    ma.ToTable("MovieActor");
                    ma.MapLeftKey("MovieId");
                    ma.MapRightKey("ActorId");
                });
        }
    }
}
