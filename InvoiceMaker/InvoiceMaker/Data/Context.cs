using InvoiceMaker.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace InvoiceMaker.Data
{
    public class Context : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }

    public static class ContextExtensions
    {
        public static void UpdateById<EntityType>(this Context context, int id, params object[] parameters)
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
            // Temporarily turn off entity validation
            context.Configuration.ValidateOnSaveEnabled = false;
            context.SaveChanges();
            context.Configuration.ValidateOnSaveEnabled = true;

        }

        public static void UpdateEntity<EntityType>(this Context context, EntityType entity)
        {
            Type entityType = typeof(EntityType);
            if (entityType.GetProperty("Id").GetValue(entity) == null)
            {
                throw new ArgumentException("Entity does not have an ID");
            }
            var dbSet = context.Set(entityType);
            dbSet.Attach(entity);
            context.Entry((object)entity).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}