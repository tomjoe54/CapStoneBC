using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class BookCollection :IEnumerable<Book>
    {
        //localstorage of books
        private List<Book> booksDB = new List<Book>();

        //indexer for books
        public Book this[int index]
        {
            get { return booksDB[index]; }
            set { booksDB.Add(value); }
        }
        public void Remove(Book book)
        {
            booksDB.Remove(book);
        }

        internal void Clear()
        {
            booksDB.Clear();
        }
        public IEnumerator<Book> GetEnumerator()
        {
            return booksDB.GetEnumerator();
        }

        internal void Sort()
        {
            booksDB.OrderBy(s => s.Title);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return booksDB.GetEnumerator();
        }
    }
}
