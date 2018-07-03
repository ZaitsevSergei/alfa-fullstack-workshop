using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Exceptions
{
    public class InvalidCardException : Exception
    {
        public InvalidCardException(string parameter) : base($"{parameter} is invalid")
        {
        }
    }
}
