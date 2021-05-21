using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Configurations.Entities;

namespace WebAPI.Models
{
    public class DatabaseContext : IdentityDbContext<ApiUser>
    {
        //Application context for code first migrations
        //add models using DbSet
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Customer> Customer { get; set; }

        //public DbSet<Days> Days { get; set; }

        //public DbSet<Hours> Hours { get; set; }

        public DbSet<Employee> Employee { get; set; }

        public DbSet<Audit> Audit { get; set; }

        public DbSet<TransType> TransType { get; set; }

        //when the model is created, automaticall seed the database with the user roles specified in Entites\RoleConfiguration.cs
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
        }



    }
}
