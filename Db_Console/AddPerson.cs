using Db_Console.Database;
using Db_Console.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Db_Console
{
    internal class AddPerson : IAddPerson
    {
        // Skapar en person i databasen.
        public void AddPersonToDatabase(Person person)
        {
            using var context = new ConsoleContext();

            context.Persons.Add(person);

            context.SaveChanges();

            Console.WriteLine("\nPerson skapad.");
        }
    }
}
