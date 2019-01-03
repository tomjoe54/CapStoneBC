using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataBase
{
    //startUp
    class Program
    {        
        static void Main(string[] args)
        {            
            try
            {
                try
                {

                    //test area 
                    // CheckOutLog test = new CheckOutLog() { BookID = 2, CardholderID = 15, CheckOutDate = DateTime.Now};
                    // AddToDataBase add = new AddToDataBase();
                    // add.AddCheckOutLog(test);
                    //load the interface object
                    UserInterface ui = new UserInterface();
                    ui.MainMenu();
                    //ui.LibrarianMenu();
                    //close the applcation
                    Console.WriteLine("goodbye");
                    Console.Read();
                }
                catch (AggregateException ex)
                {
                    Console.WriteLine("Catching exceptions.");

                    ex.Handle((inner) =>
                    {
                        if (inner is OperationCanceledException)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    });
                }
            }
            catch (AggregateException ex)
            {
                foreach (Exception inner in ex.Flatten().InnerExceptions)
                {
                    Console.WriteLine($"Exception type {inner.GetType()} From: {inner.Source}");
                    if (inner.InnerException != null)
                    {
                        GoldenNugget(inner.InnerException);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Main method exception message from Main Method: { ex.Message } ");

                if (ex.InnerException != null)
                {
                    GoldenNugget(ex.InnerException);
                }
            }
            finally
            {
                Console.Write("\nDone.");
                Console.ReadLine();
            }

        }
        private static void GoldenNugget(Exception inner)
        {
            if (inner.InnerException != null)
            {
                GoldenNugget(inner.InnerException);
            }
            else
                Console.WriteLine($"Exception type { inner.GetType()} from {inner.Source}");
        }
    }

}
    


