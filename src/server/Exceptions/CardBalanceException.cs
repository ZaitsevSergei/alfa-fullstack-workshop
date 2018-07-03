using System;

namespace Server.Exceptions
{
    public class CardBalanceException : Exception
    {
        public CardBalanceException(decimal balance, decimal withdraw) :
            base($"Card with {balance} unable to withdraw {withdraw}") { }
    }
}
