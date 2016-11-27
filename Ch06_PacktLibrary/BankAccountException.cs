using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.CS6
{
    public class BankAccountException:Exception
    {
        public BankAccountException() : base() { }
        public BankAccountException(string message) : base(message) { }
        public BankAccountException(string message, Exception innerException) : base(message, innerException) { }
    }
}
