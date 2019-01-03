using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    //holds the results of a search so it can be printed out later to include the book's info and the author's
    public class SearchResults
    {
        internal Book Book { get; set; }
        internal Person Person { get; set; }

        internal void Add(Book item)
        {
            this.Book = item;
        }
        internal void Add(Person item)
        {
            Person = item;
        }
    }
}
