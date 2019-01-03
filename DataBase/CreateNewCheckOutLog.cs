using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    /// <summary>
    /// this class creates a new checkout log to be uploaded to the database.
    /// </summary>
    internal class CreateNewCheckOutLog
    {
        internal CheckOutLog Add(Person ch, Book book)
        {
            CheckOutLog newLog = new CheckOutLog();
            newLog.CardholderID = ch.Cardholder.ID;
            newLog.BookID = book.BookID;
            newLog.CheckOutDate = DateTime.Now;            

            return newLog;
        }
    }
}
