using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Packt.CS6;

namespace Ch07_InheritanceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee e1 = new Employee { Name = "John Jones", DateOfBirth = new DateTime(1990, 7, 28) };
            e1.WriteToConsole();
            e1.EmployeeCode = "JJ001";
            e1.HireDate = new DateTime(2014, 11, 23);
            Console.WriteLine($"{e1.Name} was hired on {e1.HireDate:dd/MM/yy}");
            Console.WriteLine(e1.ToString());

            Employee aliceInEmployee = new Employee { Name = "Alice", EmployeeCode = "AA123" };
            Person aliceInPerson = aliceInEmployee;
            aliceInEmployee.WriteToConsole();
            aliceInPerson.WriteToConsole();
            Console.WriteLine(aliceInEmployee.ToString());
            Console.WriteLine(aliceInPerson.ToString());

            if (aliceInPerson is Employee) {
                Console.WriteLine($"{nameof(aliceInPerson)} IS an employee.");
                Employee e2 = (Employee)aliceInPerson;

            }

            Employee e3 = aliceInPerson as Employee;
            if (e3!=null)
            {
                Console.WriteLine($"{nameof(aliceInPerson)} AS employee.");
            }

            try
            {
                BankAccount ba = new BankAccount();
                ba.Balance = 100;
                Console.WriteLine($"Balance is {ba.Balance}");
                ba.Withdraw(150);
                Console.WriteLine($"Balance is {ba.Balance}");
            }
            catch (BankAccountException ex)
            {

                Console.WriteLine($"{ex.GetType().Name} : {ex.Message}");
            }

        }
    }
}
