using System;

namespace Server.Exceptions
{
    public class CardActitvityException : Exception
    {
        public CardActitvityException(string cardNumber, DateTime expirityDate) :
            base($"Card {cardNumber} exprired {expirityDate.Month}/{expirityDate.Year}")
        {}
    }
}
