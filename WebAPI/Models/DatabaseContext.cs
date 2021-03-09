using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<Days> Days { get; set; }

        public DbSet<Hours> Hours { get; set; }

        public DbSet<Employee> Employee { get; set; }



    }
}
