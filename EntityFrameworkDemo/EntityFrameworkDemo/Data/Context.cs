using EntityFrameworkDemo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Data
{
    class Context : DbContext
    {
        public DbSet<Person> People { get; set; }

    }
}
