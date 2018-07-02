using System;
using Server.Infrastructure;

namespace Server.Services
{
    public class TransactionService : ITransactionService
    {

        /// <summary>
        /// Award 10 bonus rubles to card
        /// </summary>
        /// <param name="card">card to award</param>
        public void AwardBonus(CardService card)
        {
            throw new NotImplementedException();
        }

        public decimal CurrencyExchange(Money moneytoExchange, CurrencyType currencyTarget)
        {
            throw new NotImplementedException();
        }
    }
}
