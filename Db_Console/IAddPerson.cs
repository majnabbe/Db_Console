using Db_Console.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Db_Console
{
    interface IAddPerson
    {
        void AddPersonToDatabase(Person person);
    }
}
