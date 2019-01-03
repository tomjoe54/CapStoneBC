using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    public class CheckOutLogCollection : IEnumerable<CheckOutLog>
    {
        //localstorage of check out logs
        private List<CheckOutLog> logDB = new List<CheckOutLog>();

        //indexer for checkout log
        internal CheckOutLog this[int index]
        {
            get { return logDB[index]; }
            set { logDB.Add(value); }
        }


        internal void Remove(CheckOutLog log)
        {
            logDB.Remove(log);
        }

        internal void Clear()
        {
            logDB.Clear();
        }

        internal void Sort()
        {
            logDB.OrderBy(s => s.CheckOutDate).ThenBy(s => s.Book.Title);
        }

        public IEnumerator<CheckOutLog> GetEnumerator()
        {
            return ((IEnumerable<CheckOutLog>)logDB).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<CheckOutLog>)logDB).GetEnumerator();
        }
    }
}
