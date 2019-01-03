using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    // this class edits, adds, removes books for the books db
   internal class EditBookDB
    {
       

        //TODO add so multple books can be added or removed. so a book's copies can be reduced and finaly remove the entry
        //add
        internal void AddBook(Book bookToAdd,LocalDataBaseStorage localDataBase)
        {
            localDataBase.BookCollection[0]=bookToAdd;
            
        }

        internal void AddBookManualy(LocalDataBaseStorage localDataBase)
        {
            //ask the user for the details
            Book newBook = new Book();            
            Console.WriteLine("enter a book ISBN");
            newBook.ISBN = Console.ReadLine();
            Console.WriteLine("enter Title");
            newBook.Title = Console.ReadLine();
            Console.WriteLine("enter Author id");
            FindBook find = new FindBook();

            //get the new book author id and check to see if it is a valid id before continuing
            string input = "";
            
                while (input != "e")
            {
                input = Console.ReadLine();
                Int32.TryParse(input, out int y);
                newBook.AuthorID = y;
                FindAuthor findAuth = new FindAuthor();
                if (!findAuth.AuthorByID(newBook.AuthorID, localDataBase))
                {
                    //cant find author id
                    Console.WriteLine($"no author matching id: {newBook.AuthorID}" +
                        "\nenter a new id or e to exit");
                }
                else
                {
                    //found author setting input to id
                    
                    input = "e";

                }
            }

            //get the number of pages
            Console.WriteLine("enter number of pages");
            newBook.NumPages = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("enter Subject");
            newBook.Subject = Console.ReadLine();
            Console.WriteLine("enter discription");
            newBook.Description = Console.ReadLine();
            Console.WriteLine("enter Publisher");
            newBook.Publisher = Console.ReadLine();
            Console.WriteLine("enter year published");
            newBook.YearPublished = Console.ReadLine();
            Console.WriteLine("enter language");
            newBook.Language = Console.ReadLine();
            Console.WriteLine("enter number of copies");
            newBook.NumberOfCopies = Convert.ToInt32(Console.ReadLine());

            //newBook.BookID = LocalDataBaseStorage.booksDB.Count;

            //print out what was just entered
            Console.WriteLine($"\nisbn: {newBook.ISBN}" +
                $"\nTitle:{newBook.Title}" +
                $"\nAuthor ID: {newBook.AuthorID}" +
                $"\nNumber of pages: {newBook.NumPages}" +
                $"\nSubject: {newBook.Subject}" +
                $"\nDescription: {newBook.Description}" +
                $"\nPublisher: {newBook.Publisher}" +
                $"\nYear Published: {newBook.YearPublished}" +
                $"\nLanguage: {newBook.Language}" +
                $"\nNumber of copies: {newBook.NumberOfCopies}");

            //add to localstorage
            AddBook(newBook, localDataBase);
            //add to sql
            AddToDataBase add = new AddToDataBase();
            add.AddBook(newBook);
        }

        //remove
        internal void RemoveBook(Book bookToRemove, LocalDataBaseStorage localDataBase)
        {
            foreach (var book in localDataBase.BookCollection)
            {
                if(book == bookToRemove)
                {
                    localDataBase.BookCollection.Remove(bookToRemove);
                }
            }
        }
        //edit

        //test good book
        //makes sure that no fields are missing and the book can be added
    }
}