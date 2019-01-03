using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    //this class updates entries in the database, like available copies, titles names ect.
    //TODO implement update date itme

    internal class UpdateDataBaseItem
    {

        //update book
        internal void UpdateBook(Book bookToUpdate)
        {
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {
                var queryBooks = (from b in context.Books
                                  where b.BookID == bookToUpdate.BookID
                                  select b);

                foreach (var b in queryBooks)
                {
                    b.ISBN = bookToUpdate.ISBN;
                    b.Title = bookToUpdate.Title;
                    b.AuthorID = bookToUpdate.AuthorID;
                    b.NumPages = bookToUpdate.NumPages;
                    b.Subject = bookToUpdate.Subject;
                    b.Description = bookToUpdate.Description;
                    b.Publisher = bookToUpdate.Publisher;
                    b.YearPublished = bookToUpdate.YearPublished;
                    b.Language = bookToUpdate.Language;
                    b.NumberOfCopies = bookToUpdate.NumberOfCopies;
                }

                //TODO assure that valid author id is used, otherwise the update wont take place
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

        //this update is made when checking out a book
        internal void UpdateBookCheckOut(Book bookToUpdate)
        {
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {

                var queryBooks = (from b in context.Books
                                  where b.BookID == bookToUpdate.BookID
                                  select b);

                foreach (var b in queryBooks)
                {
                    //found the book now can decrement it and update the database.
                    if (b.BookID == bookToUpdate.BookID)
                    {
                        b.NumberOfCopies = bookToUpdate.NumberOfCopies--;
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
        internal void UpdateBookCheckIn(Book bookToUpdate)
        {
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {

                var queryBooks = (from b in context.Books
                                  where b.BookID == bookToUpdate.BookID
                                  select b);

                foreach (var b in queryBooks)
                {
                    //found the book now can incremented it and update the database.
                    b.NumberOfCopies = bookToUpdate.NumberOfCopies++;
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

    }
}
