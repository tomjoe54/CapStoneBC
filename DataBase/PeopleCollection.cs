using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class PeopleCollection:IEnumerable<Person>
    {
        //localstorage of people
        private List<Person> peopleDB = new List<Person>();

        //indexer for people
        internal Person this[int index]
        {
            get { return peopleDB[index]; }
            set { peopleDB.Add(value); }
        }

        internal void Remove(Person person)
        {
            peopleDB.Remove(person);
        }
        internal void Sort()
        {
            peopleDB.OrderBy(s => s.LastName).ThenBy(s => s.FirstName);
        }

        internal void Clear()
        {
            peopleDB.Clear();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Person>)peopleDB).GetEnumerator();
        }

        public IEnumerator<Person> GetEnumerator()
        {
            return ((IEnumerable<Person>)peopleDB).GetEnumerator();
        }
    }
}
