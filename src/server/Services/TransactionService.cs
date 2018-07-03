using Server.Exceptions;
using Server.Infrastructure;
using Server.Models;
using System;
using System.Linq;

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
            transaction.Execute();
        }

        /// <summary>
        /// Currency exchange service
        /// </summary>
        /// <param name="moneytoExchange">Money to exchange with value and currency type</param>
        /// <param name="currencyTarget">Currency type which money shod be exchanged </param>
        /// <returns></returns>
        public decimal CurrencyExchange(Money moneytoExchange, CurrencyType currencyTarget)
        {
            if (moneytoExchange.MoneyValue <= 0) throw new MoneyNegativeValueException("Using negative or zero valuues of money is restricted");

            // find coefficient of exchange
            decimal coefficient;

            // if money is the same currency as target
            if (moneytoExchange.CurrencyType == currencyTarget)
            {
                return moneytoExchange.MoneyValue;
            }
            // else see currency exchange rate
            else
            {
                coefficient = Constants.ExchangeRate[moneytoExchange.CurrencyType.ToString("G") +
                    currencyTarget.ToString("G")];
            }

            return moneytoExchange.MoneyValue * coefficient;
        }
    }
}