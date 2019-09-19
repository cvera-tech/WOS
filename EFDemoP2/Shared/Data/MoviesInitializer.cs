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
            context.Directors.Add(michel);
            context.SaveChanges();

            var mork = new Actor("Mork Hammamamil");
            var kerr = new Actor("Kerr Fish");
            var rock = new Actor("Dawine Jnojnoj");
            context.Actors.Add(mork);
            context.Actors.Add(kerr);
            context.Actors.Add(rock);
            context.SaveChanges();

            var juju = new Movie("Jujumajni", jimbo);
            juju.Actors.Add(rock);
            jimbo.Movies.Add(juju);
            context.Movies.Add(juju);
            var photna = new Movie("Sot Wot: Pisood 1 - Photna Nemanec", michel);
            photna.Actors.Add(mork);
            photna.Actors.Add(kerr);
            michel.Movies.Add(photna);
            context.SaveChanges();
        }
    }
}
