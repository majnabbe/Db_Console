using System;
using System.Collections.Generic;
using System.Text;

namespace Db_Console
{
    interface IFindPerson
    {
        void FindPersonInDatabase();

        void FindPersonInDatabase(int a);

        void FindPersonInDatabase(string searchString);
    }
}
