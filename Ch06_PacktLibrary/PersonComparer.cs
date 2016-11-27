using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.CS6
{
    public class PersonComparer:IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int temp = x.Name.Length.CompareTo(y.Name.Length);
            if (temp == 0)
            {
                return x.Name.CompareTo(y.Name);
            }
            else
            {
                return temp;
            }
        }
    }
}
