using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataBase
{
    //this class updates the sql database with the current local storage lists.
    internal class ExportLocalStorageToSQL
    {//TODO add crud to all database

        //foreach theough a list and see if it is in the db replace update.
        internal void UpdateAll(LocalDataBaseStorage localDataBase)
        {

           

            //connect to the server
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {
                
                foreach (var book in localDataBase.BookCollection)
                {
                    var queryBooks = (from b in context.Books
                                 where b.BookID == book.BookID
                                 select b);

                    foreach (var b in queryBooks)
                    {
                        b.ISBN = book.ISBN;
                        b.Title = book.Title;
                        b.AuthorID = book.AuthorID;
                        b.NumPages = book.NumPages;
                        b.Subject = book.Subject;
                        b.Description = book.Description;
                        b.Publisher = book.Publisher;
                        b.YearPublished = book.YearPublished;
                        b.Language = book.Language;
                        b.NumberOfCopies = book.NumberOfCopies;
                    }
                }
               
                foreach (Person auth in localDataBase.PeopleCollection)
                {
                    var queryAuthors = (from a in context.Authors
                                        where a.ID == auth.PersonID
                                        select a);

                    foreach (var a in queryAuthors)
                    {
                        a.Bio = auth.Author.Bio;
                    }
                }
                foreach (Person card in localDataBase.PeopleCollection)
                {
                    var queryCH = (from c in context.Cardholders
                                        where c.ID == card.PersonID
                                        select c);

                    foreach (var c in queryCH)
                    {
                        c.Phone = card.Cardholder.Phone;
                        c.LibraryCardID = card.Cardholder.LibraryCardID;
                    }
                }

                foreach (var log in localDataBase.CheckOutLogCollection)
                {
                    var queryCL = (from c in context.CheckOutLogs
                                   where c.CheckOutLogID == log.CheckOutLogID
                                   select c);

                    foreach (var c in queryCL)
                    {
                        c.CardholderID = log.CardholderID;
                        c.BookID = log.BookID;
                        c.CheckOutDate = log.CheckOutDate;
                    }
                }

                foreach (Person lib in localDataBase.PeopleCollection)
                {
                    var queryLib = (from l in context.Librarians
                                    where l.ID == lib.PersonID
                                    select l);

                    foreach (var l in queryLib)
                    {
                        l.Phone = lib.Librarian.Phone;
                        l.UserID = lib.Librarian.UserID;
                        l.Password = lib.Librarian.Password;
                    }
                }

                foreach (Person peo in localDataBase.PeopleCollection)
                {
                    var queryPeo = (from l in context.People
                                    where l.PersonID == peo.PersonID
                                    select l);

                    foreach (var p in queryPeo)
                    {
                        p.FirstName = peo.FirstName;
                        p.LastName = peo.LastName;                        
                    }
                }


                try
                {
                    context.SaveChanges();
                }
                catch
                {
                    throw new Exception("cant save changed to database.");
                }
            }
        }
    }
}
