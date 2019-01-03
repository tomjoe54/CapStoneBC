using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class DisplayLists
    {
        LocalDataBaseStorage localDataBase = new LocalDataBaseStorage();
        FindCheckOutLog find = new FindCheckOutLog();
        FindBook findBook = new FindBook();

        internal void DisplayAll()
        {

            DisplayAuthors();
            DisplayLibrarians();
            DisplayCardHolders();
            DisplayOverdueBooks();
        }

        internal void DisplayAuthors()
        {
            Console.WriteLine("\ndisplaying a list of Authors");
            foreach (Person item in localDataBase.PeopleCollection)
            {
                if (item.Author!=null)
                {
                    Console.WriteLine(item.Print()+", bio: "+item.Author.Bio);                    
                }               
            }
        }

        internal void DisplayLibrarians()
        {
            Console.WriteLine("\ndisplaying a list of librarians");
            foreach (Person item in localDataBase.PeopleCollection)
            {
                if (item.Librarian != null)
                {
                    Console.WriteLine(item.ToString()+$"{item.Librarian.ToString()}");
                }
            }
        }
        internal void DisplayCardHolders()
        {
            Console.WriteLine("\ndisplaying a list of card dolders");
            foreach (Person item in localDataBase.PeopleCollection)
            {
                //Console.WriteLine($"ID: {item.PersonID}, First Name:{item.FirstName}, Last Name: {item.LastName}, Phone:{item.Cardholder.Phone}, " +
                //    $"Library CardID: {item.Cardholder.LibraryCardID}");

                if(item.Cardholder!= null)
                {
                   Console.WriteLine(item.ToString());
                

                //current checked out books
                List<CheckOutLog> checkedOut = find.GetLogs(item.Cardholder.ID);
                checkedOut.OrderBy(s => s.Book.Title);
                if (checkedOut != null)
                {
                        foreach (var log in checkedOut)
                        {
                            string overdue = "";
                            if (log.CheckOutDate.AddDays(30) <= DateTime.Now)
                            {
                                overdue = "over due";
                            }
                            else
                            {
                                overdue = "not over due";
                            }
                            Book boolInLog = findBook.GetBook(log.BookID, localDataBase);
                            Console.Write($"Books checked out:" +
                                $"\n\t\t\t{log.BookID} {boolInLog.ISBN} {boolInLog.Title} {log.CheckOutDate}");
                            //if display red text if book is over due
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write($" {overdue}\n");
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                }
            }
        }


        internal void DisplayOverdueBooks()
        {
            FindCardHolder find = new FindCardHolder();
            Console.WriteLine("\ndisplaying a list of over due books");
            foreach (var item in localDataBase.CheckOutLogCollection)
            {
                if (item.CheckOutDate.AddDays(30) <= DateTime.Now)
                {                    
                    Person temp = find.SearchByID(item.CardholderID);
                    Book boolInLog = findBook.GetBook(item.BookID, localDataBase);
                    Console.WriteLine($"ID: {item.BookID}, ISBN:{boolInLog.ISBN}, Title: {boolInLog.Title}, check out date:{item.CheckOutDate}" +
                        $"\tcard holder info: ID: {temp.PersonID}, First Name:{temp.FirstName}, Last Name: {temp.LastName}, Phone:{temp.Cardholder.Phone}, " +
                        $"Library CardID: {temp.Cardholder.LibraryCardID}");
                }
            }
        }
    }
}
