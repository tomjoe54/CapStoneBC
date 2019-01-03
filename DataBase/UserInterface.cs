using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    class UserInterface
    {
        LocalDataBaseStorage localDataBase = new LocalDataBaseStorage();
        FindBook findBook = new FindBook();
        FindCardHolder findCardHolder = new FindCardHolder();

        internal void ConnectToDatabase()
        {
            //connect to the server. load the data from the server to local storage.           
            localDataBase = new LocalDataBaseStorage();
        }

        bool librarianLogedIn = false;
        internal string mode = "mode: patron"; //set to patron or librarian to show what mode the app is currently set to. default is patron.
        internal void MainMenu()
        {
            ConnectToDatabase();
            bool showMainMenu = true;
            while (showMainMenu == true)
            {

                Console.Clear();
                Console.WriteLine($"1) Find a book by Title, Author, Subject, or ISBN\t\t\t{mode}" +
                    "\n2) Librarian Login" +
                    "\n3) Exit the program (save)");
                string userinput = Console.ReadLine();
                switch (userinput)
                {
                    case "1":
                        this.SearchMenu();
                        break;
                    case "2":
                        this.LibrarianLogInMenu();
                        break;
                    case "3":
                        Console.WriteLine("exiting");
                        ExportLocalStorageToSQL e = new ExportLocalStorageToSQL();
                        e.UpdateAll(localDataBase);
                        return;                        
                    default:
                        Console.WriteLine("Enter valid option");
                        break;
                }
            }
            Console.Clear();
        }

        internal void SearchMenu()
        {
            string userSearch = "";
            bool end = false;
            //search men
            while (!end)
            {
                Console.Clear();
                Console.WriteLine($"search books\t\t\t{mode}\nPlease enter search criteria. or e to exit menu");
                userSearch = Console.ReadLine();

                if (userSearch == "e" || userSearch == "")//exit option
                {
                    end = true;
                    return;
                }


                //print out sort details of books
                findBook.SearchBooks(userSearch, localDataBase);
                findBook.PrintResults();
                Console.WriteLine("\nEnter the book ID for more information on it. or press e to return to main menu");

                //ask for a specific book of which to get full details.
                string seletedBook = Console.ReadLine();
                if (seletedBook == "e" || seletedBook == "")//exit option
                {
                    end = true;
                    return;
                }
                else
                {//user didnt exit so look for desired book
                    int selection = GetGoodInt(seletedBook);

                    Console.Clear();
                    foreach (SearchResults selectedResults in findBook.searchBooksResults)
                    {
                        if (selectedResults.Book.BookID == selection)
                        {
                            findBook.PrintDetailedResults(selectedResults, localDataBase);
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                }


                Console.Clear();
            }

        }
        internal void LibrarianLogInMenu()
        {
            //login
            string userName = "";
            string userPassword = "";
            string userinput = "";

            while (userinput != "e")
            {
                LibrarianLoginAuthenticator auth = new LibrarianLoginAuthenticator();
                Console.Clear();
                Console.WriteLine($"welcome librarian\t\t\t{mode}");
                Console.WriteLine($"Please enter your username");
                userName = Console.ReadLine();
                Console.WriteLine($"Please enter your password");
                userPassword = Console.ReadLine();

                // LocalDataBaseStorage localDataBase = new LocalDataBaseStorage();



                if (auth.Check(userName, userPassword) || librarianLogedIn)
                {
                    //go to librarian menu
                    librarianLogedIn = true;
                    mode = "mode: Librarian";
                    this.LibrarianMenu();
                    userinput = "e";
                }
                else
                {
                    Console.WriteLine("cant find user name or password, press enter to try again. or enter e to return to main menu");
                }

                //exit menu
                userinput = Console.ReadLine();
                if (userinput == "e")
                {
                    //return to Main Menu
                    MainMenu();
                }
            }
        }
        internal void LibrarianMenu()
        {
            ConnectToDatabase();
            string userinput = "";
            //Librarian menu  
            while (userinput != "14")
            {
                Console.Clear();
                Console.WriteLine(
                    $"1)  Find a book by Title, Author, Subject, or ISBN\t\t\t{mode}" +
                    "\n2)  Check out a book" +
                    "\n3)  Check in a book" +
                    "\n4)  Add book(s) to the system" +
                    "\n5)  Update an existing book in the system " +
                    "\n6)  Remove book(s) from the system " +
                    "\n7)  Display the following lists:" +
                    "\n8)  Return to main menu"+
                    //"\n8)  Import xml" +
                    "\n9)  Export to xml" +
                    //"\n10) Import datebase to local storage" +
                    "\n11) Export local storage to database" 
                    //"\n12) Create cardholder" +
                    //"\n13) Remove cardholder" +
                    //"\n14) Return to main menu"
                    );

                userinput = Console.ReadLine();
                switch (userinput)
                {
                    case "1":
                        SearchMenu();
                        break;
                    case "2"://check out a book                        
                        CheckOutABookMenu();
                        break;
                    case "3"://Check in a book
                        CheckInBookMenu();
                        break;
                    case "4"://Add book(s) to the system
                        AddBookMenu();
                        break;
                    case "5"://Update an existing book in the system
                        UpdateBookMenu();
                        break;
                    case "6"://Remove book(s) from the system
                        RemoveBookMenu();
                        break;
                    case "7"://	Display the following lists:
                        DisplayMenu();
                        break;

                    case "8"://retun to main menu
                        this.MainMenu();
                        break;

                    //case "8"://import xml to db
                    //    ImportXMLtoLocalStorage newPort = new ImportXMLtoLocalStorage();
                    //    newPort.Import();
                    //    break;
                    case "9"://export to xml
                        ExportToXMLMenu();
                        break;
                    //case "10"://Import datebase to local storage
                    //    localDataBase.LoadAll();
                    //    break;
                    case "11"://Export local storage to database
                        ExportLocalStorageToSQL e = new ExportLocalStorageToSQL();
                        e.UpdateAll(localDataBase);
                        Console.WriteLine("Update finished");
                        Console.ReadLine();
                        break;
                    //case "12"://create card holder
                    //    CreateCardHolderMenu();
                    //    break;
                    //case "13"://remove card holder
                    //    RemoveCardHolderMenu();
                    //    break;
                    //case "14"://to main menu  
                    //    this.MainMenu();
                    //    break;
                    default:
                        Console.WriteLine("other");
                        break;
                }

            }
        }

        internal void DisplayMenu()
        {
            Console.WriteLine($"\t\t\t{ mode}");
            Console.Clear();
            DisplayLists lists = new DisplayLists();
            
                lists.DisplayAll();
            
            Console.ReadLine();

        }


        internal void CheckOutABookMenu()
        {
            BusinessRules br = new BusinessRules();
            bool exitCard = false;
            Console.Clear();
            while (!exitCard)
            {
                Console.WriteLine($"Checkout a book\t\t\t{mode}");
                //ask for their card number
                Console.WriteLine("please enter card number: ");
                string cardNum = Console.ReadLine();

                Person cardholder = findCardHolder.SearchByCardNumber(cardNum);
                if (cardholder == null)
                {
                    Console.WriteLine("can't find card number. try again. or press e to exit");
                    if (Console.ReadLine() == "e")
                    {
                        exitCard = true;
                        LibrarianMenu();
                    }
                }

                //use the business rules to see if the patron has any over due books
                else if (br.CheckIfHasOverdueBooks(cardholder, out CheckOutLog log,localDataBase))
                {
                    Console.WriteLine($"Over due book, ID:{log.BookID}. please return before checking out another book");
                    Console.ReadLine();
                    LibrarianMenu();
                }

                //ask for the ISBN
                Console.WriteLine("ISBN: ");
                string ISBN = Console.ReadLine();
                // verify the isbn
                Book bookToCheckOut = findBook.SearchByISBN(ISBN, localDataBase);
                if (bookToCheckOut != null)
                {
                    //check if a copie is available
                    if (br.CheckIfBookIsAvailable(bookToCheckOut, localDataBase))
                    {
                        Console.WriteLine("book is available");
                        Console.ReadLine();
                        //check out the book by updating the database                            
                        UpdateDataBaseItem update = new UpdateDataBaseItem();
                        update.UpdateBookCheckOut(bookToCheckOut);
                        //create a new checkout log to be added to the database.
                        CreateNewCheckOutLog log = new CreateNewCheckOutLog();
                        AddToDataBase addToDatabase = new AddToDataBase();
                        addToDatabase.AddCheckOutLog(log.Add(cardholder, bookToCheckOut));
                    }
                    else
                    {
                        Console.WriteLine("no copies available");
                        Console.ReadLine();
                    }
                }
            }
        }

        internal void CheckInBookMenu()
        {
            bool exit = false;
            Console.Clear();
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine($"CheckIn a book\t\t\t{mode}");
                //ask for the ISBN and card number
                Console.WriteLine("please enter card number: ");
                string cardNum = Console.ReadLine();
                Person cardholder = findCardHolder.SearchByCardNumber(cardNum);
                if (cardholder == null)
                {
                    Console.WriteLine("can't find card number. try again. or press e to exit");
                    if (Console.ReadLine() == "e")
                    {
                        exit = true;
                        LibrarianMenu();
                    }
                }
                else
                {
                    //found card holder look for book
                    Console.WriteLine("Found card" +
                        "\n enter ISBN: ");
                    string ISBN = Console.ReadLine();
                    Book bookToCheckIn = findBook.SearchByISBN(ISBN, localDataBase);
                    if (bookToCheckIn != null)
                    {
                        FindCheckOutLog find = new FindCheckOutLog();
                        //fond book. get checkout log.
                        //convert isbn input string to data type of check out log, int.
                        int.TryParse(ISBN, out int tempInt);
                        CheckOutLog log = find.GetLog(cardholder.PersonID, bookToCheckIn.BookID);
                        localDataBase.CheckOutLogCollection.Remove(log);
                        RemoveFromDataBase remove = new RemoveFromDataBase();
                        remove.RemoveCheckOutLog(log, localDataBase);
                        //update local collections
                        ConnectToDatabase();

                    }
                    else
                    {
                        Console.WriteLine($"{ISBN} not found in database");
                    }
                }
            }
        }

        //add a book
        internal void AddBookMenu()
        {
            Console.Clear();

            //ask the user for the details
            Book newBook = new Book();
            Console.WriteLine($"enter a book ISBN\t\t\t{mode}");
            newBook.ISBN = Console.ReadLine();
            Console.WriteLine("enter Title");
            newBook.Title = Console.ReadLine();
            Console.WriteLine("enter Author id");

            //get the new book author id and check to see if it is a valid id before continuing
            string input = "";

            while (input != "e")
            {
                input = Console.ReadLine();
                Int32.TryParse(input, out int y);
                newBook.AuthorID = y;
                FindAuthor findAuth = new FindAuthor();
                if (!findAuth.AuthorByID(newBook.AuthorID, localDataBase))
                {
                    //cant find author id
                    Console.WriteLine($"no author matching id: {newBook.AuthorID}" +
                        "\nenter a new id or e to exit");
                }
                else
                {
                    //found author setting input to id
                    input = "e";
                }
                
            }

            //get the number of pages
            Console.WriteLine("enter number of pages");
            newBook.NumPages = GetGoodInt();
            Console.WriteLine("enter Subject");
            newBook.Subject = Console.ReadLine();
            Console.WriteLine("enter discription");
            newBook.Description = Console.ReadLine();
            Console.WriteLine("enter Publisher");
            newBook.Publisher = Console.ReadLine();
            Console.WriteLine("enter year published");
            newBook.YearPublished = Console.ReadLine();
            Console.WriteLine("enter language");
            newBook.Language = Console.ReadLine();
            Console.WriteLine("enter number of copies");
            newBook.NumberOfCopies = GetGoodInt();

            //print out what was just entered            
            Console.WriteLine("=====");
            newBook.Print();
            Console.ReadLine();

            //add to localstorage
            EditBookDB edit = new EditBookDB();
            edit.AddBook(newBook, localDataBase);
            //add to sql
            AddToDataBase add = new AddToDataBase();
            add.AddBook(newBook);
            //update local storage
            ConnectToDatabase();
        }

        internal void CreateCardHolderMenu()
        {

            Console.Clear();
            Console.WriteLine($"\t\t\t{mode}");
            Console.WriteLine("Enter Fist Name");
            string fn = Console.ReadLine();
            Console.WriteLine("Enter Last Name");
            string ln = Console.ReadLine();
            Console.WriteLine("Enter Phone Number");
            string p = Console.ReadLine();
            Console.WriteLine("Enter Library Card Number");
            string l = Console.ReadLine();
            CreateNewCardHolder ch = new CreateNewCardHolder();
            ch.Add(fn, ln, p, l);
        }

        internal void RemoveCardHolderMenu()
        {
            Console.Clear();
            foreach (Person holder in localDataBase.PeopleCollection)
            {
                Console.WriteLine($"{holder.PersonID}, {holder.FirstName}, {holder.LastName}, {holder.Cardholder.Phone}, {holder.Cardholder.LibraryCardID}");
            }
            //select the person to remove
            Console.WriteLine("enter ID of card holder to remove");
            int removePerson = GetGoodInt();
            FindPerson find = new FindPerson();
            Person toBeRemoved = find.GetPersonByID(removePerson);
            Console.WriteLine($"remove: {find.GetPersonByID(removePerson).FirstName}? enter y for yes, n for no.");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "y":
                    //call remove
                    RemoveFromDataBase remove = new RemoveFromDataBase();
                    remove.RemoveCardHolder(toBeRemoved, localDataBase);
                    Console.WriteLine("removing");
                    Console.ReadLine();
                    break;
                case "n":
                    break;
            }
        }

        internal void UpdateBookMenu()
        {
            Console.Clear();
            Console.WriteLine($"\t\t\t{mode}");
            Book updateBook = new Book();

            Console.WriteLine("enter the BookID to edit");
            updateBook.BookID = GetGoodInt();
            Console.WriteLine("enter new ISBN");
            updateBook.ISBN = Console.ReadLine();
            Console.WriteLine("enter new Title");
            updateBook.Title = Console.ReadLine();
            Console.WriteLine("enter new AuthorID");           
            updateBook.AuthorID = GetGoodInt();
            Console.WriteLine("enter new NumPages");
            updateBook.NumPages = GetGoodInt();
            Console.WriteLine("enter new Subject");
            updateBook.Subject = Console.ReadLine();
            Console.WriteLine("enter new Description");
            updateBook.Description = Console.ReadLine();
            Console.WriteLine("enter new Publisher");
            updateBook.Publisher = Console.ReadLine();
            Console.WriteLine("enter new YearPublished");
            updateBook.YearPublished = Console.ReadLine();
            Console.WriteLine("enter new Language");
            updateBook.Language = Console.ReadLine();
            Console.WriteLine("enter new NumberOfCopies");
            updateBook.NumberOfCopies = GetGoodInt();
            try
            {
                //update connect to database
                UpdateDataBaseItem update = new UpdateDataBaseItem();
                //update sql database
                update.UpdateBook(updateBook);
                UpdateLocalStorage updateLocal = new UpdateLocalStorage();
                //update localstorage
                updateLocal.UpdateBook(updateBook,localDataBase);
            }

            catch (Exception)
            {
                throw;
            }
            ConnectToDatabase();
        }

        // makes sure that the user inputs a valid string that can be parsed into a int and returns that int.
        internal int GetGoodInt()
        {
            int tempInt = 0;
            bool temp1 = false;
            temp1 = int.TryParse(Console.ReadLine(), out tempInt);
            while (!temp1)
            {
                if (temp1)
                {
                    return tempInt;
                }
                else
                {
                    Console.WriteLine("bad value. please enter a valid number.");
                    temp1 = int.TryParse(Console.ReadLine(), out tempInt);
                }

            }
            return tempInt;
        }
        internal int GetGoodInt(string input)
        {
            int tempInt = 0;
            bool temp1 = false;
            temp1 = int.TryParse(input, out tempInt);
            while (!temp1)
            {
                if (temp1)
                {
                    return tempInt;
                }
                else
                {
                    Console.WriteLine("bad value. please enter a valid number.");
                    temp1 = int.TryParse(Console.ReadLine(), out tempInt);
                }

            }
            return tempInt;
        }

        internal void RemoveBookMenu()
        {
            Console.Clear();

            Console.WriteLine($"enter the BookID to remove\t\t\t{mode}");
            int bookIDToDelete = GetGoodInt();
            try
            {
               
                //find the book to remove
                Book book = findBook.GetBook(bookIDToDelete,localDataBase);
                findBook.PrintDetailedResults(book, localDataBase);
                Console.WriteLine("\nhow many do you want to remove?");
                string seletedBook = Console.ReadLine();
                int numToRemove = GetGoodInt(seletedBook);                
                //remove from database
                if (book.NumberOfCopies <= numToRemove)
                {
                    //remove all books and and logs
                    RemoveFromDataBase removesql = new RemoveFromDataBase();
                    removesql.RemoveBook(book, localDataBase);
                    //remove from local storage
                    RemoveFromLocalStorage remove = new RemoveFromLocalStorage();
                    remove.RemoveBook(book, localDataBase);
                }
                else
                {
                    //remove copies
                    book.NumberOfCopies -= numToRemove;
                    //update sql database
                    ExportLocalStorageToSQL e = new ExportLocalStorageToSQL();
                    e.UpdateAll( localDataBase);
                    findBook.PrintDetailedResults(book, localDataBase);
                    Console.ReadLine();
                }
                
                
                Console.WriteLine($"book removed");
                book.Print();
                //ExportSQLToXML.Export();

                //TODO need to make sure all checkoutlogs are cleared first

            }
            catch (Exception)
            {

                throw;
            }
            ConnectToDatabase();
        }

        /// <summary>
        /// /disabled
        /// </summary>
        internal void ExportToXMLMenu()
        {
            ExportSQLToXML e = new ExportSQLToXML();
            e.Export();
            Console.ReadLine();
        }

        //internal Cardholder GetCardHolderMenu()
        //{
        //    bool exit = false;
        //    while (!exit)
        //    {
        //        Console.WriteLine("please enter card number: ");
        //        string cardNum = Console.ReadLine();

        //        Cardholder cardholder = FindCardHolder.SearchByCardNumber(cardNum);
        //        if (cardholder == null)
        //        {
        //            Console.WriteLine("can't find card number. try again. or press e to exit");
        //            if (Console.ReadLine() == "e")
        //            {
        //                LibrarianMenu();
        //                exit = true;                       
        //            }
        //            return null;     
        //        }
        //        else
        //        {
        //            CheckOutABookMenu();
        //            return cardholder;
        //        }

        //    }
        //}

    }
}