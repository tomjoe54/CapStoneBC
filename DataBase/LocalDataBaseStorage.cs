using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    //loads the data from the database to the local storage.  
    public class LocalDataBaseStorage
    {
        private BookCollection bookCollection = new BookCollection();
        public BookCollection BookCollection { get => bookCollection; set => bookCollection = value; }

        private CheckOutLogCollection checkOutLogCollection = new CheckOutLogCollection();
        public CheckOutLogCollection CheckOutLogCollection { get => checkOutLogCollection; set => checkOutLogCollection = value; }

        private PeopleCollection peopleCollection = new PeopleCollection();
        public PeopleCollection PeopleCollection { get => peopleCollection; set => peopleCollection = value; }




        //constructor
        internal LocalDataBaseStorage()
        {
            LoadPeople();
            LoadBooks();
            LoadLogs();
            //Connect();
            { }
        }

        public LocalDataBaseStorage(string test) { }

        internal void LoadAll()
        {
            LoadPeople();
            LoadBooks();
            LoadLogs();
            Connect();
        }

        internal void LoadPeople()
        {
            peopleCollection.Clear();
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {
                var queryPeople = (from pe in context.People select pe);

                foreach (var p in queryPeople)
                {
                    //to allow the list to maintain the child connection add if states to preserve the type
                    


                    if (p.Librarian != null)
                    {
                        peopleCollection[0] = p;
                    }
                    if (p.Author != null)
                    {
                        peopleCollection[0] = p;
                    }
                    if (p.Cardholder != null)
                    {
                        peopleCollection[0] = p;
                    }
                }               
            }

            peopleCollection.Sort();
        }

        internal void LoadBooks()
        {
            bookCollection.Clear();
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {
                var queryBooks = (from b in context.Books select b);

                foreach (var b in queryBooks)
                {
                    if (b.Author != null)
                    {
                        if (b.CheckOutLogs != null)
                        {
                            bookCollection[0] = b;
                        }
                    }
                }
            }

            bookCollection.Sort();
        }

        internal void LoadLogs()
        {
            checkOutLogCollection.Clear();
            using (LibraryInformationEntities context = new LibraryInformationEntities())
            {
                var queryLogs = (from c in context.CheckOutLogs select c);


                foreach (var c in queryLogs)
                {
                    if (c.Book != null && c.Cardholder != null)
                    {
                        checkOutLogCollection[0] = c;
                    }
                }
            }
        }


        //connects books to authors logs to card holders ect
        internal void Connect()
        {
            foreach (var b in BookCollection)
            {
                foreach (var p in PeopleCollection)
                {
                    if (b.AuthorID == p.PersonID&&p.Author!=null)
                    {
                        
                        b.Author = p as Author;
                    }
                }
            }
        }

        // internal void SortAll()
        //{

        //    authorsDB.OrderBy(s => s.LastName).ThenBy(s => s.FirstName);
        //    booksDB.OrderBy(s => s.Title);
        //    cardHoldersDB.OrderBy(s => s.LastName).ThenBy(s => s.FirstName);
        //    peopleDB.OrderBy(s => s.LastName).ThenBy(s => s.FirstName);
        //    LibrariansDB.OrderBy(s => s.LastName).ThenBy(s => s.FirstName);
        //    checkOutLogsDB.OrderBy(s => s.CheckOutDate).ThenBy(s => s.Book.Title);

        //}

        //internal void LoadDataBases()
        //{
        //    using (LibraryInformationEntities context = new LibraryInformationEntities())
        //    {
        //        foreach (var a in context.Authors) { authorsDB.Add(a); }
        //        foreach (var b in context.Books) { booksDB.Add(b); }
        //        foreach (var c in context.Cardholders) { cardHoldersDB.Add(c); }
        //        foreach (var c in context.CheckOutLogs) { checkOutLogsDB.Add(c); }
        //        foreach (var l in context.Librarians) { LibrariansDB.Add(l); }
        //        foreach (var p in context.People) { peopleDB.Add(p); }                
        //    }
        //    SortAll();
        //}



    }
}
