using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.CS6
{
    public class Employee:Person
    {
        public string EmployeeCode { get; set; }
        public DateTime HireDate { get; set; }
        public new void WriteToConsole()
        {
            Console.WriteLine($"{Name}'s birthday is {DateOfBirth:dd/MM/yy} and hire date was {HireDate:dd/MM/yy}");
        }

        public override string ToString()
        {
            return $"{ Name} is {EmployeeCode}";
        }
    }
}
