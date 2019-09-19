using System.Data.Entity;
using Shared.Models;

namespace Shared.Data
{
    public class MoviesInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            var jimbo = new Director("Jimbo Dingo");
            var michel = new Director("Michelelele Aby");
            context.Directors.Add(jimbo);
            context.Movies.Add(new Movie("Jujumajni", jimbo));
            context.Movies.Add(new Movie("Sot Wot: Pisood 1 - Photna Nemanec", michel));
            context.SaveChanges();
        }
    }
}
