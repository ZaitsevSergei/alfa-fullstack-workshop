using System;

namespace Server.Exceptions
{
    public class InvalidMoneyValue : Exception
    {
        public InvalidMoneyValue(decimal value) :
            base($"{value} is restricted. Value must be greather than 0")
        { }
    }
}
