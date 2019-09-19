using Shared.Data;
using Shared.Repositories;
using System;
using System.Data.Entity;
using System.Linq;

namespace MoviesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer<Context>(new MoviesInitializer());

            //using (var context = new Context())
            //{
            //    context.Database.Log = m => Console.WriteLine(m);
            //    var repo = new MovieRepository(context);
            //    var moviesList = repo.GetList(m => m.Id);
            //    moviesList.ForEach(m => Console.WriteLine(m.Title));
            //}

            //using (var context = new Context())
            //{
            //    context.Database.Log = m => Console.WriteLine(m);
            //    var repo = new MovieRepository(context);
            //    var movie = repo.GetSingle(1);
            //    //var movie = context.Movies.Where(m => m.Id == 1).FirstOrDefault();
            //    Console.WriteLine(movie.Title);
            //}

            using (var context = new Context())
            {
                context.Database.Log = m => Console.WriteLine(m);
                var repo = new MovieRepository(context);
                var moviesList = repo.GetList();
                moviesList.ForEach(m => Console.WriteLine($"{m.Title} directed by {m.Director.Name}"));
            }

            using (var context = new Context())
            {
                context.Database.Log = m => Console.WriteLine(m);

                var directors = context.Directors
                    .Include(d => d.Movies)
                    .ToList();

                directors.ForEach(d =>
                {
                    var movies = d.Movies.Select(m => m.Title).ToList();
                    var movieTitles = string.Join(", ", movies);
                    Console.WriteLine($"{d.Name} ({movieTitles})");
                });
            }

            Console.ReadKey();
        }
    }
}
