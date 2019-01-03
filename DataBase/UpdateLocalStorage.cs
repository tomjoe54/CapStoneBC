using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class UpdateLocalStorage
    {
        

        //TODO implement local update
        //update a book by in local storage
        internal void UpdateBook(Book newBookUpdate, LocalDataBaseStorage localDataBase)
        {
            foreach (var oldBook in localDataBase.BookCollection)
            {
                if (newBookUpdate.BookID == oldBook.BookID)
                {
                    oldBook.ISBN = newBookUpdate.ISBN;
                    oldBook.Title = newBookUpdate.Title;
                    oldBook.AuthorID = newBookUpdate.AuthorID;
                    oldBook.NumPages = newBookUpdate.NumPages;
                    oldBook.Subject = newBookUpdate.Subject;
                    oldBook.Description = newBookUpdate.Description;
                    oldBook.Publisher = newBookUpdate.Publisher;
                    oldBook.YearPublished = newBookUpdate.YearPublished;
                    oldBook.Language = newBookUpdate.Language;
                    oldBook.NumberOfCopies = newBookUpdate.NumberOfCopies;
                }
            }
        }
        internal void UpdateAuthor(Author newAuthorUpdate, LocalDataBaseStorage localDataBase)
        {

        }
        internal void UpdatePerson(Person newPersonUpdate, LocalDataBaseStorage localDataBase)
        {

        }
        internal void UpdateCardPerson (Cardholder newCardHolderUpdate, LocalDataBaseStorage localDataBase)
        {

        }
        internal void UpdateLibrarian(Librarian newLibrarianUpdate, LocalDataBaseStorage localDataBase)
        {

        }
        internal void UpdateCheckOutLog(CheckOutLog newCheckOutLogUpdate, LocalDataBaseStorage localDataBase)
        {

        }        
    }
}
