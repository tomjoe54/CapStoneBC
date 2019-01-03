using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class FindLibrarian
    {
        LocalDataBaseStorage localDataBase = new LocalDataBaseStorage();

        internal bool IsLibrarian(Person person)
        {
            foreach (var librarian in localDataBase.PeopleCollection)
            {
                if (librarian.PersonID == person.PersonID)
                {
                    return true;                    
                }
            }
                return false;
        }
        internal Librarian GetLibrarianByID(int lookUp)
        {

            //search the DB
            try
            {
                foreach (Librarian librarian in localDataBase.PeopleCollection)
                {
                    SearchResults temp = new SearchResults();
                    if (librarian.Person.PersonID == lookUp)
                    {
                        return librarian;
                    }
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }

            return null;
        }

        internal Librarian GetLibrarianByPerson(Person lookUp)
        {

            //search the DB
            try
            {
                foreach (Librarian librarian in localDataBase.PeopleCollection)
                {
                    SearchResults temp = new SearchResults();
                    if (librarian.Person.PersonID == lookUp.PersonID)
                    {
                        return librarian;
                    }
                }

            }
            catch (Exception ex)
            {

                //Console.WriteLine(ex.Message);  
                
            }  
            return null;
        }
    }
}
