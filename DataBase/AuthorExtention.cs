using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    partial class Author:Person
    {
        public Author(int personID, string firstName, string lastName,string bio) : base(personID, firstName, lastName)
        {
            this.Bio = bio;
        }

        public override string Print()
        {
            string temp = base.Print() + $" bio:{ this.Bio}";
            return base.Print() +this.Bio;
        }
        public override string ToString()
        {
            return base.ToString()+ Bio;
        }
    }
}
