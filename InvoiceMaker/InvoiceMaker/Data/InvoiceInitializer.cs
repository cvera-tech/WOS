using InvoiceMaker.Models;
using System;
using System.Data.Entity;

namespace InvoiceMaker.Data
{
    public class InvoiceInitializer : DropCreateDatabaseAlways<Context>
    {
        protected override void Seed(Context context)
        {
            var clients = new Client[] 
            {
                new Client() { Name = "Jar Jar Binks", IsActive = true },
                new Client() { Name = "Jar Jar Binkle", IsActive = true },
                new Client() { Name = "Han Solo", IsActive = false },
                new Client() { Name = "Han Duo", IsActive = true },
                new Client() { Name = "King Kong", IsActive = true },
                new Client() { Name = "Donkey Kong", IsActive = false },
                new Client() { Name = "Mickey Mouse", IsActive = true }
            };

            var workTypes = new WorkType[]
            {
                new WorkType() { Name = "Window Washing", Rate = 15.75m },
                new WorkType() { Name = "Window Soiling", Rate = 22.50m },
                new WorkType() { Name = "Hang Gliding", Rate = 53.40m },
                new WorkType() { Name = "Kessel Run", Rate = 11.99m },
                new WorkType() { Name = "Ritual Chanting", Rate = 42.54m }
            };

            var worksDone = new WorkDone[]
            {
                new WorkDone() { Client = clients[0], WorkType = workTypes[2], StartedOn = new DateTimeOffset(2019, 9, 20, 14, 0, 0, new TimeSpan(-4, 0, 0)) },
                new WorkDone() { Client = clients[0], WorkType = workTypes[1], StartedOn = new DateTimeOffset(2019, 9, 21, 16, 45, 0, new TimeSpan(-4, 0, 0)) },
                new WorkDone() { Client = clients[6], WorkType = workTypes[4], StartedOn = new DateTimeOffset(2019, 12, 31, 11, 45, 0, new TimeSpan(-4, 0, 0)) },
                new WorkDone() { Client = clients[2], WorkType = workTypes[3], StartedOn = new DateTimeOffset(2019, 12, 12, 22, 0, 0, new TimeSpan(-4, 0, 0)) }
            };

            context.Clients.AddRange(clients);
            context.WorkTypes.AddRange(workTypes);
            context.WorksDone.AddRange(worksDone);
            context.SaveChanges();
        }
    }
}