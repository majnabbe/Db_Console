using Db_Console.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Db_Console.Database
{
    internal class ConsoleContext : DbContext
    {
        private const string DatabaseName = "DbConsoleApp";
        public DbSet<Person> Persons { get; set;}
        public object Person { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($"Server=localhost;Database={DatabaseName};User Id=sa;Password=password;");
        }
    }
}
