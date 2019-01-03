using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataBase;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace DataBaseTest
{
    [TestClass]
    public class UnitTest1
    {
        private BookCollection bookCollection = new BookCollection();
        internal BookCollection BookCollection { get => bookCollection; set => bookCollection = value; }
        [TestMethod]
        public void CountXMLElementsBooks()
        {
            //test the number of elements on the xml and the local storage are correct     

            ////act
            //create books to test and xml
            List<Book> booksDB = new List<Book>();
            //create 2 books add them to the database list.
            Book newbook = new Book(1, "111111", "11", 7, 1, "sub1", "des1", "pub1", "1911", "1", 1);
            booksDB.Add(newbook);
            newbook = new Book(2, "2222", "22", 7, 2, "sub2", "des2", "pub2", "1912", "2", 2);
            booksDB.Add(newbook);

            //create a xml document
            XDocument document = new XDocument();
            Console.WriteLine("creating new xml doc");
            //export the books to a xml document
            document = new XDocument(
         new XDeclaration("1.0", "utf-8", "yes"),
         new XComment("Contents of Books table from LibraryInformation database"),
         new XElement("BooksTest",
             from b in booksDB
             select new XElement("Book",
                 new XElement("BookID", b.BookID),
                 new XElement("ISBN", b.ISBN),
                 new XElement("Title", b.Title),
                 new XElement("AuthorID", b.AuthorID),
                 b.NumPages == null ? null :
                    new XElement("NumPages", b.NumPages),
                 b.Subject == null ? null :
                    new XElement("Subject", b.Subject),
                 b.Description == null ? null :
                    new XElement("Description", b.Description),
                 b.Publisher == null ? null :
                    new XElement("Publisher", b.Publisher),
                 b.YearPublished == null ? null :
                    new XElement("YearPublished", b.YearPublished),
                 b.Language == null ? null :
                    new XElement("Language", b.Language),
                 new XElement("NumberOfCopies", b.NumberOfCopies))));


            ////arrange            
            int numOfEleInXML = document.Root.Elements().Count();
            int expected = booksDB.Count();
            ////assert

            Assert.AreEqual(expected, numOfEleInXML);
        }

        [TestMethod]
        public void StringSearchCount()
        {
            //Test the string search method to make sure the correct number of books is returned

            //arrange
            LocalDataBaseStorage localStorage = new LocalDataBaseStorage("test");

            
            //create 2 books add them to the database list.
            Book newbook = new Book(1, "111111", "11", 7, 1, "sub1", "des1", "pub1", "1911", "1", 1);
            localStorage.BookCollection[0] = newbook;
            newbook = new Book(2, "2222", "22", 7, 2, "sub2", "des2", "pub2", "1912", "2", 2);
            localStorage.BookCollection[0]=newbook;
            
            FindBook findBook = new FindBook();

              
            string userInPut = "sub";
            //act
            findBook.SearchBooks(userInPut, localStorage);
            int NumInStorage = findBook.searchBooksResults.Count();

            //assert
            Assert.AreEqual(2, NumInStorage);
            Assert.AreNotEqual(3, NumInStorage);
        }

        [TestMethod]
        public void CheckNumOfBooksCheckedOut()
        {
            //act
            BusinessRules br = new BusinessRules();
            LocalDataBaseStorage localStorage = new LocalDataBaseStorage("test");            
            Book newbook = new Book(1, "111111", "11", 7, 1, "sub1", "des1", "pub1", "1911", "1", /*num of copies=*/1);
            localStorage.BookCollection[0] = newbook;
            //arrange
            int availableBooks = br.NumCopiesInstock(newbook, localStorage);

            //assert
            Assert.AreEqual(1, availableBooks);
        }
    }
}
