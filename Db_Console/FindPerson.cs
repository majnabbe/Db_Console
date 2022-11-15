using Db_Console.Database;
using Db_Console.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Db_Console
{
    internal class FindPerson : IFindPerson
    {
        // Hämtar specifik person baserat på id.
        public void FindPersonInDatabase(int id)
        {
            using var context = new ConsoleContext();

            var personId = context.Persons.Find(id);

            if (personId == null)
            {
                Console.WriteLine("\nId saknas.");
                return;
            }
            Console.Clear();
            Console.WriteLine($"Id {personId.Id}: {personId.FirstName} {personId.LastName}, {personId.Address}.");
        }

        // Hämtar alla personer.
        public void FindPersonInDatabase()
        {
            using var context = new ConsoleContext();

            var allPersons = context.Persons;

            foreach (var item in allPersons)
            {
                Console.WriteLine($"Id {item.Id}: {item.FirstName} {item.LastName}, {item.Address}.");
            }
        }

        // Mycket, mycket begränsad sökfunktion. Använd inte mer än ett sökord, annars blir det pannkaka.
        public void FindPersonInDatabase(string searchString)
        {
            // Några vanliga tecken som kan dyka upp.
            char[] splitCharcters = { ' ', ',', '.' };

            string[] singleWords = searchString.Split(splitCharcters, StringSplitOptions.RemoveEmptyEntries);

            List<Person> resultList = new List<Person>();

            using var context = new ConsoleContext();
            var result = context.Persons;

            // Som det är nu skrivs listan över om mer än ett sökord används och hittas.
            foreach (var word in singleWords)
            {
                resultList = result.Where(s => s.Id.ToString().Contains(word) ||
                                         s.FirstName.Contains(word) ||
                                         s.LastName.Contains(word) ||
                                         s.Address.Contains(word)).ToList();
            }

            if (resultList.FirstOrDefault() == null)
            {
                Console.WriteLine("\nIngen träff.");
            }
            else
            {
                Console.WriteLine("\nResultat:\n");

                foreach (var item in resultList)
                {
                    Console.WriteLine($"Id {item.Id}: {item.FirstName} {item.LastName}, {item.Address}.");
                }
            }
        }
    }
}
