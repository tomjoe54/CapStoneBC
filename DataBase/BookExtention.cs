using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    partial class Book
    {
        //constructor
        public Book(int bookID, string isbn, string title, int authorID, int pages, string subject, string description, string publisher,
            string year, string language, int copies)
        {
            this.BookID = bookID;
            this.ISBN = isbn;
            this.Title = title;
            this.AuthorID = authorID;
            this.NumPages = pages;
            this.Subject = subject;
            this.Description = description;
            this.Publisher = publisher;
            this.YearPublished = year;
            this.Language = language;
            this.NumberOfCopies = copies;
        }

        internal void Print()
        {
            Console.WriteLine($"ID: {this.BookID}, " +
                   $"\nTitle: {this.Title}, " +
                   $"\nISBN: {this.ISBN} " +
                   $"\nAuthor ID: {this.AuthorID }" +
                   $"\nPages: {this.NumPages}" +
                   $"\nSubject: {this.Subject}, " +
                   $"\nDescription: {this.Description}, " +
                   $"\nPublisher: {this.Publisher}, " +
                   $"\nYearPublished: {this.YearPublished}, " +
                   $"\nLanguage: {this.Language}, " +
                   $"\nNumberOfCopies: {this.NumberOfCopies}");
        }

        public override string ToString()
        {
            return this.BookID + this.Title;
        }

    }
}