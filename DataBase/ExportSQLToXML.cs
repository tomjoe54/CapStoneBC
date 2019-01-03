using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataBase
{
    class ExportSQLToXML
    {
        


        internal void Export()
        {
            //connect to database
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {

                List<Author> authorsDB = (from a in context.Authors select a).ToList();
                List<Book> booksDB = (from b in context.Books select b).ToList();
                List<Cardholder> cardHoldersDB = (from c in context.Cardholders select c).ToList();
                List<CheckOutLog> checkOutLogsDB = (from col in context.CheckOutLogs select col).ToList();
                List<Librarian> LibrariansDB = (from l in context.Librarians select l).ToList();
                List<Person> peopleDB = (from p in context.People select p).ToList();

                //create new xml docs
                XDocument document = new XDocument();
                Console.WriteLine("creating new xml doc");
                
                //authors
                document = new XDocument(
             new XDeclaration("1.0", "utf-8", "yes"),
             new XComment("Contents of Authors table from LibraryInformation database"),
             new XElement("Authors",
                 from a in authorsDB select 
                 new XElement("Author",
                 new XElement("ID", a.ID),
                     a.Bio == null ? null :
                     new XElement("Bio", a.Bio))));

                document.Save("Authors.xml");
                Console.WriteLine("saving authors");

                
                //books
                document = new XDocument(
             new XDeclaration("1.0", "utf-8", "yes"),
             new XComment("Contents of Books table from LibraryInformation database"),
             new XElement("Books",
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

                
                document.Save("Books.xml");
                Console.WriteLine("saving books");

                //card holders
                document = new XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XComment("Contents of Cardholders table from LibraryInformation database"),
              new XElement("Cardholders",
                  from c in cardHoldersDB  
                  select new XElement("Cardholder",
                     new XElement("ID", c.ID),
                     new XElement("Phone", c.Phone),
                     new XElement("LibraryCardID", c.LibraryCardID))));
                
                document.Save("Cardholders.xml");
                Console.WriteLine("saving card holders");

                //checkout log
                document = new XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XComment("Contents of CheckOutLog table in LibraryInformation database"),
              new XElement("CheckOutLogs",
                  from c in checkOutLogsDB
                  select new XElement("CheckOutLog",
                     new XElement("CheckOutLogID", c.CheckOutLogID),
                     new XElement("CardholderID", c.CardholderID),
                     new XElement("BookID", c.BookID),
                     new XElement("CheckOutDate", c.CheckOutDate))));
                
                
                document.Save("CheckOutLog.xml");
                Console.WriteLine("saving checkoutlog");

                //librarians
                document = new XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XComment("Contents of Librarians table in LibraryInformation database"),
              new XElement("Librarians",
                  from l in LibrariansDB
                  select new XElement("Librarian",
                     new XElement("ID", l.ID),
                     new XElement("Phone", l.Phone),
                     new XElement("UserID", l.UserID),
                     new XElement("Password", l.Password))));

                document.Save("Librarians.xml");
                Console.WriteLine("saving librarians");

                //person
                document = new XDocument(
              new XDeclaration("1.0", "utf-8", "yes"),
              new XComment("Contents of People table from LibraryInformation database"),
              new XElement("People",
                  from p in peopleDB  
                  select new XElement("Person",
                     new XElement("PersonID", p.PersonID),
                     new XElement("FirstName", p.FirstName),
                     new XElement("LastName", p.LastName))));
                //save the xml
               
                document.Save("People.xml");
                document.Save("People.xml");
                Console.WriteLine("saving People");
            }
        }
    }
}
