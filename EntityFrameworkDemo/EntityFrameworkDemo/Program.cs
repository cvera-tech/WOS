using EntityFrameworkDemo.Data;
using EntityFrameworkDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Reflection;
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

            var context = new Context();
            context.Database.Log = (message) => Console.WriteLine(message);


            using (context)
            {

                if (context.People.Count() == 0)
                {
                    AddPeople(context);
                }

                //var filteredPeople = context.People.Where(IsStarWarsFan).ToList();
                //filteredPeople.ForEach(p => Console.WriteLine(p));

                //var john = context.People.Where(p => p.Name == "John").First();
                //var entry = context.Entry(john);

                //john.Weight = 190;
                //var entry2 = context.Entry(john);
                SelectPeople(context);
                context.DetachAllEntities();
                context.UpdateById<Person>(1, "Name", "John", "Weight", (decimal)2000);
                context.DetachAllEntities();
                SelectPeople(context);
            }
            Console.ReadKey();
        }

        private static void AddPeople(Context context)
        {
            context.People.Add(new Person()
            {
                Name = "John",
                BirthDate = new DateTime(1995, 4, 24),
                Weight = 160,
                IsStarWarsFan = true
            });
            context.People.Add(new Person()
            {
                Name = "John2",
                BirthDate = new DateTime(1995, 4, 24),
                Weight = 160,
                IsStarWarsFan = false
            });
            context.SaveChanges();

        }

        private static bool IsStarWarsFan(Person person)
        {
            return person.IsStarWarsFan;
        }

        private static void DeleteById(Context context, int id)
        {
            var person = new Person() { Id = id };
            context.Entry(person).State = EntityState.Deleted;
            context.SaveChanges();
        }

        private static void SelectPeople(Context context)
        {
            //SELECT * FROM People
            var people = context.People.ToList();
            people.ForEach(p => Console.WriteLine(p));
        }

        private static void SelectPeople(Context context, Func<Person, bool> predicate)
        {
            var people = context.People.Where(predicate).ToList();
            people.ForEach(p => Console.WriteLine(p));
        }
    }

    public static class ExtensionMethods
    {
        internal static void DetachAllEntities(this Context context)
        {
            var changedEntries = context.ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added ||
                            e.State == EntityState.Modified ||
                            e.State == EntityState.Deleted)
                .ToList();

            foreach (var entry in changedEntries)
            {
                entry.State = EntityState.Detached;
            }
        }
        internal static void UpdateById<EntityType>(this Context context, int id, params object[] parameters)
        {
            if (parameters.Count() % 2 != 0)
            {
                throw new ArgumentException("Invalid number of parameters");
            }

            Type entityType = typeof(EntityType);
            EntityType entity = Activator.CreateInstance<EntityType>();
            entityType.GetProperty("Id").SetValue(entity, id);
            var set = context.Set(entityType);
            set.Attach(entity);
            for (int index = 0; index < parameters.Length; index += 2)
            {
                var parameterName = (string)parameters[index];
                var parameterValue = parameters[index + 1];

                entityType.GetProperty(parameterName).SetValue(entity, parameterValue);
                context.Entry((object)entity).Property(parameterName).IsModified = true;
            }
            try
            {
                context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                Console.WriteLine("What the heck");
            }
        }
    }
}
