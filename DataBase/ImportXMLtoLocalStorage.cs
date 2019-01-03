//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Data.Entity;
//using System.Xml.Linq;


////not working right now
//namespace DataBase
//{
//    //this method imports the xml data into the local storage
//    internal class ImportXMLtoLocalStorage
//    {
//        LocalDataBaseStorage localDataBase = new LocalDataBaseStorage();

//        internal void Import()
//        {
//            localDataBase.PeopleCollection = LoadAuthors();
//            LocalDataBaseStorage.booksDB = LoadBooks();
//            LocalDataBaseStorage.cardHoldersDB = LoadCardHolders();
//            LocalDataBaseStorage.checkOutLogsDB = LoadCheckOutLog();
//            LocalDataBaseStorage.LibrariansDB = LoadLibrarians();
//            LocalDataBaseStorage.peopleDB = LoadPerson();
//        }

//        internal List<Author> LoadAuthors()
//        {
//            /////Authors
//            //Get contents of XML file using LINQ to XML.
//            var authorsXML = (
//                    from a in XDocument.Load("Authors.xml").Descendants("Author")
//                    select a).ToList();

//            //create a temp storage to hold the xml data before sending it to local storage      
//            List<Person> authors = new List<Person>(authorsXML.Count);

//            Author author = null;

//            // Store contents from LINQ to XML into List collection
//            foreach (var auth in authorsXML)
//            {
//                if()
//                author = new Author();

//                //Filling the author object 
//                try
//                {
//                    Int32.TryParse(auth.Element("ID").Value, out int x);
//                    author.ID = x;
//                }
//                catch { author.ID = -1; }
//                try
//                {
//                    author.Bio = auth.Element("Bio").Value;
//                }
//                catch
//                {
//                    author.Bio = "empty";
//                }
//                //Appending the row to the List collection
//                authors.Add(author);

//                Cardholder newCH = null;

//                foreach (var ch in cardHoldersXML)
//                {
//                    newCH = new Cardholder();

//                    try
//                    {
//                        Int32.TryParse(ch.Element("ID").Value, out int a);
//                        newCH.ID = a;
//                    }
//                    catch { newCH.ID = -1; }
//                    try
//                    {
//                        newCH.Phone = ch.Element("Phone").Value;
//                    }
//                    catch { newCH.Phone = "-1"; }
//                    try
//                    {
//                        newCH.LibraryCardID = ch.Element("LibraryCardID").Value;
//                    }
//                    catch { newCH.LibraryCardID = "-1"; }


//                    cardHolders.Add(newCH);
//                }

//                return cardHolders;
//            }
//        }

//            return authors;
//        }

//        internal List<Cardholder> LoadCardHolders()
//        {
//            //TODO: add thid fix book.xml to cardholders
//            var cardHoldersXML = (
//                    from c in XDocument.Load("Books.xml").Descendants("Book")
//                    select c).ToList();

//            List<Cardholder> cardHolders = new List<Cardholder>(cardHoldersXML.Count);

//            Cardholder newCH = null;

//            foreach (var ch in cardHoldersXML)
//            {
//                newCH = new Cardholder();

//                try
//                {
//                    Int32.TryParse(ch.Element("ID").Value, out int a);
//                    newCH.ID = a;
//                }
//                catch { newCH.ID = -1; }
//                try
//                {
//                    newCH.Phone = ch.Element("Phone").Value;
//                }
//                catch { newCH.Phone = "-1"; }
//                try
//                {
//                    newCH.LibraryCardID = ch.Element("LibraryCardID").Value;
//                }
//                catch { newCH.LibraryCardID = "-1"; }


//                cardHolders.Add(newCH);
//            }

//            return cardHolders;
//        }

//        internal List<Librarian> LoadLibrarians()
//        {
//            var librariansXML = (
//                    from b in XDocument.Load("Librarians.xml").Descendants("Librarian")
//                    select b).ToList();

//            List<Librarian> librarians = new List<Librarian>(librariansXML.Count);

//            Librarian newLib = null;

//            foreach (var lib in librariansXML)
//            {
//                newLib = new Librarian();
//                try
//                {
//                    Int32.TryParse(lib.Element("ID").Value, out int a);
//                    newLib.ID = a;
//                }
//                catch { newLib.ID = -1; }

//                try
//                {
//                    newLib.Phone = lib.Element("Phone").Value;
//                }
//                catch { newLib.Phone = "no phone"; }
//                try
//                {
//                    newLib.UserID = lib.Element("UserID").Value;
//                }
//                catch { newLib.UserID = "no user id"; }
//                try
//                {
//                    newLib.Password = lib.Element("Password").Value;
//                }
//                catch { newLib.Password = "no password"; }



//                librarians.Add(newLib);
//            }


//            return librarians;
//        }
//        internal List<Person> LoadPerson()
//        {
//            var personsXML = (
//                    from p in XDocument.Load("People.xml").Descendants("Person")
//                    select p).ToList();

//            List<Person> persons = new List<Person>(personsXML.Count);

//            Person newPerson = null;

//            foreach (var person in personsXML)
//            {
//                newPerson = new Person();
//                try
//                {
//                    Int32.TryParse(person.Element("PersonID").Value, out int a);
//                    newPerson.PersonID = a;
//                }
//                catch { newPerson.PersonID = -1; }
//                try
//                {
//                    newPerson.FirstName = person.Element("FirstName").Value;
//                }
//                catch { newPerson.FirstName = "empty"; }
//                try
//                {
//                    newPerson.LastName = person.Element("LastName").Value;
//                }
//                catch { newPerson.LastName = "empty"; }


//                persons.Add(newPerson);
//            }

//            return persons;
//        }

//        internal List<Book> LoadBooks()
//        {
//            AppDomain root = AppDomain.CurrentDomain;

//            /////Books
//            //Get contents of XML file using LINQ to XML.
//            var booksXML = (
//                    from b in XDocument.Load("Books.xml").Descendants("Book")
//                    select b).ToList();

//            //create a temp collection
//            List<Book> books = new List<Book>(booksXML.Count);
//            Book newBook = null;

//            // Store contents from LINQ to XML into List collection
//            foreach (var book in booksXML)
//            {
//                newBook = new Book();

//                try
//                {
//                    if (book.Element("BookID").Value != null)
//                    {
//                        Int32.TryParse(book.Element("BookID").Value, out int x);
//                        newBook.BookID = x;
//                    }
//                    else
//                    {
//                        newBook.BookID = 404;
//                    }
//                }
//                catch { newBook.BookID = 404; }
//                try
//                {
//                    if (book.Element("ISBN").Value != null)
//                    {
//                        newBook.ISBN = book.Element("ISBN").Value;
//                    }
//                    else
//                    {
//                        newBook.ISBN = "null";
//                    }
//                }
//                catch { newBook.ISBN = "null"; }
//                try
//                {
//                    if (book.Element("Title").Value != null)
//                    {
//                        newBook.Title = book.Element("Title").Value;
//                    }
//                    else
//                    {
//                        newBook.Title = "empty";
//                    }
//                }
//                catch { newBook.Title = "empty"; }
//                try
//                {
//                    if (book.Element("AuthorID").Value != null)
//                    {
//                        Int32.TryParse(book.Element("AuthorID").Value, out int y);
//                        newBook.AuthorID = y;
//                    }
//                    else
//                    {
//                        newBook.AuthorID = 404;
//                    }
//                }
//                catch { newBook.AuthorID = 404; }
//                try
//                {
//                    if (book.Element("NumPages").Value != null)
//                    {
//                        Int32.TryParse(book.Element("NumPages").Value, out int z);
//                        newBook.NumPages = z;
//                    }
//                    else
//                    {
//                        newBook.NumPages = 404;
//                    }
//                }
//                catch { newBook.NumPages = 404; }                
//                try
//                {
//                    newBook.Subject = book.Element("Subject").Value;
//                }
//                catch
//                {newBook.Subject = "No subject";}
//                try
//                {
//                    if (book.Element("Description").Value != null)
//                    {
//                        newBook.Description = book.Element("Description").Value;
//                    }
//                    else
//                    {
//                        newBook.Description = "no discription";
//                    }
//                }
//                catch{newBook.Description = "no discription";}
//                try
//                {
//                    if (book.Element("Publisher").Value != null)
//                    {
//                        newBook.Publisher = book.Element("Publisher").Value;
//                    }
//                    else
//                    {
//                        newBook.Publisher = "no publisher";
//                    }
//                }
//                catch { newBook.Publisher = "no publisher"; }
//                try
//                {
//                    if (book.Element("YearPublished").Value != null)
//                    {
//                        newBook.YearPublished = book.Element("YearPublished").Value;
//                    }
//                    else
//                    {
//                        newBook.YearPublished = "no year";
//                    }
//                }
//                catch { newBook.YearPublished = "no year"; }
//                try
//                {
//                    if (book.Element("Language").Value != null)
//                    {
//                        newBook.Language = book.Element("Language").Value;
//                    }
//                    else
//                    {
//                        newBook.Language = "no language set";
//                    }
//                }
//                catch { newBook.Language = "no language set"; }
//                try
//                {
//                    if (book.Element("NumberOfCopies").Value != null)
//                    {
//                        Int32.TryParse(book.Element("NumberOfCopies").Value, out int a);
//                        newBook.NumberOfCopies = a;
//                    }
//                    else
//                    {
//                        newBook.NumberOfCopies = 0;
//                    }
//                }
//                catch { newBook.NumberOfCopies = 0; }

//                books.Add(newBook);
//            }

//            return books;
//        }
//        internal List<CheckOutLog> LoadCheckOutLog()
//        {
//            //Get contents of XML file using LINQ to XML.
//            var checkOutLogXML = (
//                    from b in XDocument.Load("Books.xml").Descendants("Book")
//                    select b).ToList();

//            List<CheckOutLog> checkOutLog = new List<CheckOutLog>(checkOutLogXML.Count);
//            CheckOutLog newCOL = null;

//            foreach (var col in checkOutLogXML)
//            {
//                newCOL = new CheckOutLog();
//                try
//                {
//                    Int32.TryParse(col.Element("CheckOutLogID").Value, out int a);
//                    newCOL.CheckOutLogID = a;
//                }
//                catch { newCOL.CheckOutLogID = -1; }
//                try
//                {
//                    Int32.TryParse(col.Element("CardholderID").Value, out int b);
//                    newCOL.CardholderID = b;
//                }
//                catch{ newCOL.CardholderID = -1; }
//                try
//                {
//                    Int32.TryParse(col.Element("BookID").Value, out int c);
//                    newCOL.BookID = c;
//                }
//                catch{ newCOL.BookID = -1; }
//                try
//                {
//                    DateTime checkOutDate = DateTime.Parse(col.Element("CheckOutDate").Value);
//                    newCOL.CheckOutDate = checkOutDate;
//                }
//                catch { newCOL.CheckOutDate = DateTime.Now; }
               
//                checkOutLog.Add(newCOL);
//            }

//            return checkOutLog;
//        }
//    }
//}
