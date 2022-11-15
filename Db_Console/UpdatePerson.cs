using Db_Console.Database;
using Db_Console.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Db_Console
{
    internal class UpdatePerson : IUpdatePerson
    {
        // Uppdaterar en person baserat på id.
        public void UpdatePersonInDatabase(int id)
        {
            using var context = new ConsoleContext();
            var person = context.Persons.Find(id);

            if (person == null) 
            {
                Console.WriteLine("\nId saknas.");
                return; 
            }

            Console.WriteLine($"\nPerson som uppdateras: Id {person.Id}, {person.FirstName} {person.LastName}, {person.Address}.\n");

            Console.WriteLine("Ange uppgifter i samtliga fält:\n");
            Console.Write("Förnamn: ");
            string firstName = Console.ReadLine();
            Console.Write("Efternamn: ");
            string lastName = Console.ReadLine();
            Console.Write("Adress: ");
            string address = Console.ReadLine();

            person.FirstName = firstName;
            person.LastName = lastName;
            person.Address = address;

            context.SaveChanges();

            Console.WriteLine("\nPerson uppdaterad.");
        }
    }
}
