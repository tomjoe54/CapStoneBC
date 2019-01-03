using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    internal class FindCardHolder
    {
        LocalDataBaseStorage localDataBase = new LocalDataBaseStorage();

        internal bool IsCardHolder(Person person)
        {
            foreach (var holder in localDataBase.PeopleCollection)
            {
                if (holder.PersonID == person.PersonID)
                {
                    return true;
                }
            }
            return false;
        }
        internal Cardholder GetCardHolder(Person person)
        {
            foreach (Cardholder holder in localDataBase.PeopleCollection)
            {
                if (holder.ID == person.PersonID)
                {
                    return holder;
                }
            }
            return null;
        }
        //search the local storage for the card number
        internal Person SearchByCardNumber(string cardNumber)
        {
            foreach (Person ch in localDataBase.PeopleCollection)
            {
                if (ch.Cardholder != null)
                {
                    if (ch.Cardholder.LibraryCardID == cardNumber)
                    { //found the card number
                        return ch;
                    }
                }
            }
            //number not found           
            return null;
        }

        //search the local storage for the card number
        internal Person SearchByID(int id)
        {
            foreach (Person ch in localDataBase.PeopleCollection)
            {
                if (Convert.ToInt32(ch.PersonID) == id)
                { //found the card number
                    return ch;
                }
            }
            //number not found           
            return null;
        }
    }
}
