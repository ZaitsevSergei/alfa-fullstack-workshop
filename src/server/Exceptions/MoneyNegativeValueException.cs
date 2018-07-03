using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Exceptions
{
    public class MoneyNegativeValueException : Exception
    {
        public MoneyNegativeValueException(string message) : base(message)
        {

        }
    }
}
