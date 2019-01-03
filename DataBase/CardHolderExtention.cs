using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
   public partial class Cardholder : Person
    {
        public Cardholder(int personID, string firstName, string lastName, string phoneNum, string libCardID)
            : base(personID, firstName, lastName)
        {
            this.Phone = phoneNum;
            this.LibraryCardID = libCardID;
        }

        public override string ToString()
        {
            return base.ToString() +$"Phone: {Phone}, library cardID: {LibraryCardID}";
        }
    }
}
