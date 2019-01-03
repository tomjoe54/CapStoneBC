using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataBase
{
    //this adds new authors, books, log, ect to the database.
    internal class AddToDataBase
    {
        LocalDataBaseStorage localDataBase = new LocalDataBaseStorage();

        //add a author
        internal void AddAuthor(Author newAutor)
        {
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {
                context.Authors.Add(newAutor);
                localDataBase.PeopleCollection[0]=newAutor as Author;

                try
                {
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    
                }
            }
        }

        //add a book
        internal void AddBook(Book newBook)
        {
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {
                context.Books.Add(newBook);
                localDataBase.BookCollection[0] = (newBook);
                try
                {
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    
                }

            }
        }

        //add a card holder
        internal void AddCardholder(Cardholder newCardholder)
        {
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {
                context.Cardholders.Add(newCardholder);
                localDataBase.PeopleCollection[0] = newCardholder as Cardholder;
                try
                {
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        //add a checkout log
        internal void AddCheckOutLog(CheckOutLog newCheckOutLog)
        {
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {
                context.CheckOutLogs.Add(newCheckOutLog);
                localDataBase.CheckOutLogCollection[0] = newCheckOutLog;
                try
                {
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        //add a libraryian
        internal void AddLibrarians(Librarian newLibrarian)
        {
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {
                context.Librarians.Add(newLibrarian);
                localDataBase.PeopleCollection[0] = newLibrarian as Librarian;
                try
                {
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        //add a person
        internal void AddPerson(Person newPerson)
        {
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {
                context.People.Add(newPerson);
                localDataBase.PeopleCollection[0] = newPerson;
                try
                {
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
