using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class FindCheckOutLog
    {
        LocalDataBaseStorage localDataBase = new LocalDataBaseStorage();

        //returns all check out logs checked out by the card holder
        internal List<CheckOutLog> GetLogs(int cardHolderID)
        {
            List<CheckOutLog> matches = new List<CheckOutLog>();
            foreach (var log in localDataBase.CheckOutLogCollection)
            {
                if (log.CardholderID == cardHolderID)
                {
                    matches.Add(log);
                }
            }
            return matches;
        }

        internal CheckOutLog GetLog(int cardHolderID, int bookID)
        {
             
            foreach (var log in localDataBase.CheckOutLogCollection)
            {
                if (log.CardholderID == cardHolderID && log.BookID == bookID)
                {
                    return log;
                }
            }
            return null;
        }

        //returns all check out logs with the book id
        internal List<CheckOutLog> SearchLogsByBookID(int bookID)
        {
            List<CheckOutLog> matches = null;
            foreach (var log in localDataBase.CheckOutLogCollection)
            {
                if (log.BookID == bookID)
                {
                    matches.Add(log);
                }
            }
            return matches;
        }
    }
}


                                
