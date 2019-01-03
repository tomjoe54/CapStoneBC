using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    partial class Librarian : Person
    {
        //extending the librarian to inherit person constructor
        public Librarian() { }

        public Librarian(int personID, string firstName, string lastName, string phoneNum, string userID, string password)
            : base(personID,firstName,lastName)
        {
            this.Phone = phoneNum;
            this.UserID = userID;
            this.Password = password;
        }

        public override string ToString()
        {
            return $" password: {this.Password}, UserID: {this.UserID}, Phone: {this.Phone}";
        }
    }
}
