using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    //todo add interface to add unit faces
    /*Business Rules: 
         * 1). A card holder with overdue books will not be allowed to check-out any books until the overdue book(s) are returned; 
         * 2). No book can be checked out if no copies are available.  
         *                 Note that several options will require you to calculate how many copies of a specific book are available.  
         *                 Make sure this code is not duplicated.
         */
    public class BusinessRules
    {
        //LocalDataBaseStorage localDataBase = new LocalDataBaseStorage();

        //checks to see if the patron has any overdue books
        internal bool CheckIfHasOverdueBooks(Person cardholder, out CheckOutLog overDueLog, LocalDataBaseStorage localDataBase)
        {
            //search for a log for the card holder
            foreach (var log in localDataBase.CheckOutLogCollection)
            { 
                //check to see if the book is overdue
                if (log.CardholderID == cardholder.Cardholder.ID)
                {
                    if(log.CheckOutDate.AddDays(30)<= DateTime.Now)
                    {
                        overDueLog =log;
                        return true;
                    }
                }
            }
            //no overdue books found
            overDueLog = null; 
            return false;
        }
        //looks through the local storage to see if there is an available copie to be checked out
        internal bool CheckIfBookIsAvailable(Book book, LocalDataBaseStorage localDataBase)
        {
            //count how many books have been checked out
            int checkedOut = CountCopiesOut(book, localDataBase);//how many copies have been checked out
           
            //check how many books are available
            FindBook findBook = new FindBook();
            if (findBook.GetBook(book, localDataBase).NumberOfCopies <= checkedOut)
            {
                //no available copies
                return false;
            }
            // copies are available
            else return true;
        }

        public int NumCopiesInstock(Book book, LocalDataBaseStorage localDataBase)
        {
            FindBook findBook = new FindBook();
            return findBook.GetBook(book, localDataBase).NumberOfCopies - CountCopiesOut(book, localDataBase);
        }

        internal int CountCopiesOut(Book book, LocalDataBaseStorage localDataBase)
        {
            int checkedOut = 0;
            foreach (var log in localDataBase.CheckOutLogCollection)
            {
                if (log.BookID == book.BookID)
                {
                    checkedOut++;
                }
            }
            return checkedOut;
        }


    }
}
