using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class RemoveFromLocalStorage
    {
        

        internal void RemoveBook(Book book, LocalDataBaseStorage localStorage)
        {
            foreach (var bookToRemove in localStorage.BookCollection)
            {
                if (book.BookID == bookToRemove.BookID)
                {
                    try
                    {
                        localStorage.BookCollection.Remove(bookToRemove);
                        return;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }
    }
}
