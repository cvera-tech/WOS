using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Database.SetInitializer(new DropCreateDatabaseAlways<Context>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<Context>());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());

            using (var context = new Context())
            {
                //AddPeople(context);
                context.Database.Log = (message) => Console.WriteLine(message);

                // SELECT * FROM People WHERE IsStarWarsFan = 1
                //var people = context.People.ToList();
                //people.ForEach(p => Console.WriteLine(p.Name));
                var filteredPeople = context.People.Where(IsStarWarsFan).ToList();
                filteredPeople.ForEach(p => Console.WriteLine(p.Name));
            }
            Console.ReadKey();
        }

        static void AddPeople(Context context)
        {
            context.People.Add(new Person()
            {
                Name = "John2",
                BirthDate = new DateTime(1995, 4, 24),
                Weight = 160,
                IsStarWarsFan = false
            });

            context.SaveChanges();
        }

        static bool IsStarWarsFan(Person person)
        {
            return person.IsStarWarsFan;
        }
    }
}
