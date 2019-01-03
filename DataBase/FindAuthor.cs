using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    class FindAuthor
    {
        //if the author is found returns true
        internal bool AuthorByID(int id, LocalDataBaseStorage localDataBase)
        {
            bool found = false;
            foreach (Person p in localDataBase.PeopleCollection)
            {
                if (p.Author != null)
                {
                    if (p.Author.ID== id)
                    {
                        found = true;
                    }
                }
            }
            return found;
        }

    }
}
