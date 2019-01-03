using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
   internal class LibrarianLoginAuthenticator
    {
        LocalDataBaseStorage localDataBase = new LocalDataBaseStorage();

        internal bool Check(string userName, string userPassword)
        {
            foreach (var lib in localDataBase.PeopleCollection)

                if (lib.Librarian != null)
                {
                    if (userName == lib.Librarian.UserID && userPassword == lib.Librarian.Password)
                    {
                        return true;
                    }
                }
            return false;
        }
    }
}

