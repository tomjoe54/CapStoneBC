using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    class FindPerson
    {
        internal Person GetPersonByID(int lookUp)
        {
            LocalDataBaseStorage localDataBase = new LocalDataBaseStorage();

            //search the DB
            try
            {
                foreach (var person in localDataBase.PeopleCollection)
                {
                    SearchResults temp = new SearchResults();
                    if (person.PersonID == lookUp)
                    {
                        return person;
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
