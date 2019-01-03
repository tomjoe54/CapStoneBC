using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{

    /// <summary>
    /// If the user selects the first option (Find), they are asked to enter a search string.	
    /// Once the search string is validated the program lists out books where the title, author, subject, or ISBN has the search string within it.
    /// For example, searching for “Tom” might display “Tom Sawyer” as well as books by Tom Clancy.
    /// If no match is found, then indicate that.

    /// </summary>
    public class FindBook
    {
        // store search results in a list to be displayed
        public List<SearchResults> searchBooksResults = new List<SearchResults>();



        //search by isbn
        public Book SearchByISBN(string isbn, LocalDataBaseStorage localDataBase)
        {
            foreach (Book book in localDataBase.BookCollection)
            {
                if (book.ISBN == isbn)
                {
                    return book;
                }
            }
            return null;
        }
        
        //search by title
        public void SearchBooks(string userInput, LocalDataBaseStorage localDataBase)
        {
            //clean the collection before adding new items           
            searchBooksResults.Clear();
            //search the DB
            try
            {
               //todo use link to simplify this to a were clase... localDataBase.BookCollection
                foreach (Book book in localDataBase.BookCollection)
                {
                    SearchResults temp = new SearchResults();
                    if (book.Title.ToUpper().Contains(userInput.ToUpper()) 
                        || book.Subject.ToUpper().Contains(userInput.ToUpper()) 
                        || book.ISBN.ToUpper().Contains(userInput.ToUpper()))
                        //todo icomp
                    {
                        temp.Add(book);

                        foreach (var author in localDataBase.PeopleCollection)
                        {
                            if (book.AuthorID == author.PersonID)
                            {
                                temp.Add(author);                                
                            }
                        }
                        searchBooksResults.Add(temp);
                    }
                }
                //search by author name
                foreach (var auth in localDataBase.PeopleCollection)
                {
                    if(auth.Author!= null && auth.FirstName.ToUpper().Contains(userInput.ToUpper()) || auth.LastName.ToUpper().Contains(userInput.ToUpper()))
                    {
                        //check all the books published by author
                        foreach (var b in localDataBase.BookCollection)
                        {
                            if (b.AuthorID == auth.PersonID)//match
                            {
                                bool added = false;
                                //check that it isnst already added
                                foreach (var match in searchBooksResults)
                                {                                   
                                    if (b.BookID == match.Book.BookID)
                                    {
                                        added = true;
                                    }
                                }
                                if (!added)
                                {
                                    SearchResults newR = new SearchResults();
                                    newR.Add(b);
                                    newR.Add(auth);
                                    searchBooksResults.Add(newR);
                                }
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
            if (searchBooksResults.Count == 0)
            {
                Console.Clear();
                Console.WriteLine("no books found with that search criteria");
            }
        }
        //search by ID
        public Book GetBook(Book lookUp, LocalDataBaseStorage localDataBase)
        {
            //clean the collection before adding new items           
            searchBooksResults.Clear();
            //search the DB
            try
            {
                foreach (Book book in localDataBase.BookCollection)
                {
                    SearchResults temp = new SearchResults();
                    if (book.BookID==lookUp.BookID)
                    {
                        return book;
                    }
                }
                
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }
            
            return null;
        }
        //search by ID
        public Book GetBook(int lookUp, LocalDataBaseStorage localDataBase)
        {
            //clean the collection before adding new items           
            searchBooksResults.Clear();
            //search the DB
            try
            {
                foreach (Book book in localDataBase.BookCollection)
                {
                    SearchResults temp = new SearchResults();
                    if (book.BookID == lookUp)
                    {
                        return book;
                    }
                }

            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
            }

            return null;
        }

        public void PrintDetailedResults(SearchResults userInput, LocalDataBaseStorage localDataBase)
        {
            /// •	This portion of the user interface (UI) should simply display the key elements about 
            /// the book (book ID, title, author (first name, last name), publisher, year published), 
            /// one line per book
            BusinessRules br = new BusinessRules();
            int numberOfAvailableCopies = br.NumCopiesInstock(userInput.Book, localDataBase);
                Console.WriteLine($"ID: {userInput.Book.BookID}, " +
                    $"\nTitle: {userInput.Book.Title}, " +
                    $"\nISBN: {userInput.Book.ISBN} " +
                    $"\nAuthor Name: {userInput.Person.FirstName } {userInput.Person.LastName}, " +
                    $"\nSubject: {userInput.Book.Subject}, " +
                    $"\nDescription: {userInput.Book.Description}, " +
                    $"\nPublisher: {userInput.Book.Publisher}, " +
                    $"\nYearPublished: {userInput.Book.YearPublished}, " +
                    $"\nLanguage: {userInput.Book.Language}, " +
                    $"\nNumberOfCopies: {userInput.Book.NumberOfCopies}");
            if (numberOfAvailableCopies <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Available Copies: {numberOfAvailableCopies}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else { }
            Console.Write($"Available Copies: {numberOfAvailableCopies}");

        }
        public void PrintDetailedResults(Book userInput, LocalDataBaseStorage localDataBase)
        {
            /// •	This portion of the user interface (UI) should simply display the key elements about 
            /// the book (book ID, title, author (first name, last name), publisher, year published), 
            /// one line per book
            BusinessRules br = new BusinessRules();
            int numberOfAvailableCopies = br.NumCopiesInstock(userInput, localDataBase);
            Console.WriteLine($"ID: {userInput.BookID}, " +
                $"\nTitle: {userInput.Title}, " +
                $"\nISBN: {userInput.ISBN} " +
                $"\nAuthor Name: {userInput.Author.FirstName } {userInput.Author.LastName}, " +
                $"\nSubject: {userInput.Subject}, " +
                $"\nDescription: {userInput.Description}, " +
                $"\nPublisher: {userInput.Publisher}, " +
                $"\nYearPublished: {userInput.YearPublished}, " +
                $"\nLanguage: {userInput.Language}, " +
                $"\nNumberOfCopies: {userInput.NumberOfCopies}");
            if (numberOfAvailableCopies <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Available Copies: {numberOfAvailableCopies}");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else { }
            Console.Write($"Available Copies: {numberOfAvailableCopies}");

        }


        public void PrintResults()
        {
            /// •	This portion of the user interface (UI) should simply display the key elements about 
            /// the book (book ID, title, author (first name, last name), publisher, year published), 
            /// one line per book
            //TODO add book availibiliy to search print
            foreach (SearchResults sr in searchBooksResults)
            {
                Console.WriteLine($"ID: {sr.Book.BookID}, " +
                    $"Title: {sr.Book.Title}, " +
                    $"Author Name: {sr.Person.FirstName } {sr.Person.LastName}, " +
                    $"Publisher: {sr.Book.Publisher}, " +
                    $"YearPublished: {sr.Book.YearPublished}, " 
                   );
            }
        }

        
        

    }

    
}
