using System;
using System.Linq;
using Server.Infrastructure;
using Server.Models;

namespace Server.Services
{
    public class TransactionService : ITransactionService
    {
        readonly ICardService cardService = new CardService();

        /// <summary>
        /// Award 10 bonus rubles to card
        /// </summary>
        /// <param name="card">card to award</param>
        public void AwardBonus(Card card)
        {
            if (!cardService.CheckCardEmmiter(card.CardNumber))
            {
                return;
            }

            Transaction transaction = new Transaction(
                Repository.Transactions.Max(x => x.TransactionId) + 1,
                DateTime.Now,
                new Money(10, CurrencyType.RUB),
                Repository.AlfaBank,
                card
                );
        }

        public decimal CurrencyExchange(Money moneytoExchange, CurrencyType currencyTarget)
        {
            throw new NotImplementedException();
        }
    }
}
