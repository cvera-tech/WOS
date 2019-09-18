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

    /// <summary>
    /// This class contains extension methods for the the application's custom DbContext
    /// implementation class. I wrote this to learn how to write extension methods, even
    /// though the methods could easily be included in the Context class.
    /// </summary>
    public static class ContextExtensions
    {
        /// <summary>
        /// This method updates a row in the database through an entity represented by 
        /// the input parameters.
        /// 
        /// The parameters must follow the following order:
        /// {`property1 name`, `property1 value`, `property2 name`, `property2 value`, ...}
        /// Having an odd number of parameters causes an exception to be thrown.
        /// 
        /// NOTE: This method temporarily disables automatic validation to allow partially
        /// initialized entities to be updated (e.g. Properties with the Required attribute 
        /// can be left null). Since automatic validation is disabled, all input parameters
        /// MUST be manually validated prior to calling this method.
        /// </summary>
        /// <typeparam name="EntityType">The type of the entity to update.</typeparam>
        /// <param name="context">The Context object for updating the database.</param>
        /// <param name="id">The primary key Id of the entity.</param>
        /// <param name="parameters">The array of property names and values to update.</param>
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
            
            context.Configuration.ValidateOnSaveEnabled = false;
            context.SaveChanges();
            context.Configuration.ValidateOnSaveEnabled = true;

        }

        /// <summary>
        /// This method updates a row in the database through an input instance of an 
        /// entity. The entity must have a valid Id property, and all other properties
        /// must pass automatic validation
        /// 
        /// </summary>
        /// <typeparam name="EntityType">The type of the entity to update.</typeparam>
        /// <param name="context">The Context object for updating the database.</param>
        /// <param name="entity">The entity to update.</param>
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