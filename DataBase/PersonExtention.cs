using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{

    public partial class Person
    {
        public Person() { }
        public Person(int id, string firstName, string lastName)
        {
            this.PersonID = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public virtual string Print()
        {
            string output = $"ID: {this.PersonID}, First Name: {this.FirstName}, Last Name: {this.LastName}";

            return output;
        }

        public override string ToString()
        {
            return $"{this.PersonID} {this.FirstName} {this.LastName}";
        }

    }
}
