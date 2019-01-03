using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    //this class removes a item from the database on the server, like a book, person or other.

    internal class RemoveFromDataBase
    {
        //Connect to local storage
        LocalDataBaseStorage localDataBase = new LocalDataBaseStorage();

        internal void RemoveCheckOutLog(CheckOutLog checkOutLog,LocalDataBaseStorage localDataBase)
        {
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {

                var queryLog = (from l in context.CheckOutLogs
                                   where l.CheckOutLogID == checkOutLog.CheckOutLogID
                                   select l);

                foreach (var l in queryLog)
                {
                    if (l.CheckOutLogID == checkOutLog.CheckOutLogID)
                    {
                        context.CheckOutLogs.Remove(l);
                        localDataBase.CheckOutLogCollection.Remove(l);
                    }
                }

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
        
        internal void RemoveCardHolder(Cardholder cardholderToRemove, LocalDataBaseStorage localDataBase)
        {
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {

                var queryHolder = (from ch in context.Cardholders
                                   where ch.Person.PersonID == cardholderToRemove.Person.PersonID
                                   select ch);

                foreach (var c in queryHolder)
                {
                    if (c.PersonID == cardholderToRemove.PersonID)
                    {
                        context.People.Remove(c);
                        localDataBase.PeopleCollection.Remove(c);
                    }
                }

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
        internal void RemoveCardHolder(Person cardholderToRemove, LocalDataBaseStorage localDataBase)
        {
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {
                var queryHolder = (from ch in context.Cardholders
                                   where ch.Person.PersonID == cardholderToRemove.PersonID
                                   select ch);

                foreach (var c in queryHolder)
                {
                    if (c.Person.PersonID == cardholderToRemove.PersonID)
                    {
                        context.Cardholders.Remove(c);
                        localDataBase.PeopleCollection.Remove(c);
                    }
                }

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

        internal void RemoveLibrarian(Librarian librarianToRemove, LocalDataBaseStorage localDataBase)
        {
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {

                var queryLibrarian = (from l in context.Librarians
                                      where l.PersonID == librarianToRemove.PersonID
                                      select l);

                foreach (var l in queryLibrarian)
                {
                    if (l.PersonID == librarianToRemove.PersonID)
                    {
                        context.Librarians.Remove(l);
                        localDataBase.PeopleCollection.Remove(l);
                    }
                }


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

        internal void RemoveBook(Book bookToDelete, LocalDataBaseStorage localDataBase)
        {
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {
                var queryBook = (from b in context.Books
                                   where b.BookID == bookToDelete.BookID
                                   select b);

                foreach (var b in queryBook)
                {
                    if (b.BookID == bookToDelete.BookID)
                    {
                        //remove check logs for this book
                        var queryCheckOutLog = (from co in context.CheckOutLogs
                                                where co.BookID == bookToDelete.BookID
                                         select co);

                        foreach (var item in queryCheckOutLog)
                        {
                            context.CheckOutLogs.Remove(item);
                            localDataBase.CheckOutLogCollection.Remove(item);
                        }

                        //now that the check out logs have been removed remove the book
                        context.Books.Remove(b);
                        localDataBase.BookCollection.Remove(b);
                    }
                }

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
        internal void RemoveBook(Book bookToDelete,int numOfCopiesToRemove, LocalDataBaseStorage localDataBase)
        {
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {
                var queryBook = (from b in context.Books
                                 where b.BookID == bookToDelete.BookID
                                 select b);

                foreach (var b in queryBook)
                {
                    if (b.BookID == bookToDelete.BookID)
                    {
                        //remove check logs for this book
                        var queryCheckOutLog = (from co in context.CheckOutLogs
                                                where co.BookID == bookToDelete.BookID
                                                select co);

                        foreach (var item in queryCheckOutLog)
                        {
                            context.CheckOutLogs.Remove(item);
                            localDataBase.CheckOutLogCollection.Remove(item);
                        }

                        //now that the check out logs have been removed remove the book
                        context.Books.Remove(b);
                        localDataBase.BookCollection.Remove(b);
                    }
                }

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

        internal void RemovePerson(Person personToRemove, LocalDataBaseStorage localDataBase)
        {
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {

                var queryPerson = (from p in context.People
                                   where p.PersonID == personToRemove.PersonID
                                   select p);

                foreach (var p in queryPerson)
                {
                    if (p.PersonID == personToRemove.PersonID)
                    {
                        context.People.Remove(p);
                    }
                }

                try
                {
                    context.SaveChanges();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }





            //to remove a person need to check if that person is a card holder and or a librarian as those will also 
            //need to be removed.

            //FindLibrarian findLib = new FindLibrarian();
            //try
            //{
            //    if (findLib.IsLibrarian(person))
            //    {
            //        LocalDataBaseStorage.LibrariansDB.Remove(findLib.GetLibrarianByPerson(person));                   
            //    }
            //    if (FindCardHolder.IsCardHolder(person))
            //    {
            //        LocalDataBaseStorage.cardHoldersDB.Remove(FindCardHolder.GetCardHolder(person));
            //    }

            //    else
            //    {

            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }
    }
}
