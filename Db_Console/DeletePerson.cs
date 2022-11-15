using Db_Console.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Db_Console
{
    internal class DeletePerson : IDeletePerson
    {
        // Tar bort person baserat på id.
        public void DeletePersonFromDatabase(int id)
        {
            using var context = new ConsoleContext();
            var deletePersonId = context.Persons.Find(id);

            if (deletePersonId == null)
            {
                Console.WriteLine("\nId saknas.");
                return;
            }

            context.Remove(deletePersonId);
            context.SaveChanges();

            Console.WriteLine($"\nFöljande person är borttagen: Id {deletePersonId.Id}, {deletePersonId.FirstName} {deletePersonId.LastName}, {deletePersonId.Address}.");
        }
    }
}
