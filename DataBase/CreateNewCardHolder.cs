using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class CreateNewCardHolder
    {
        //this creates a new partron card holder and adds it to the database
        internal Cardholder Add(string firstName, string lastName, string phone, string cardNum)
        {
            Cardholder newPerson = new Cardholder()
            {
                FirstName = firstName,
                LastName = lastName
            };

            Cardholder newCardHolder = new Cardholder()
            {                 
                Phone = phone,
                LibraryCardID = cardNum
            };

            AddToDataBase add = new AddToDataBase();
            
            //add to database
            add.AddPerson(newPerson);
            add.AddCardholder(newCardHolder);


            return newCardHolder;
        }
        
    }
}
