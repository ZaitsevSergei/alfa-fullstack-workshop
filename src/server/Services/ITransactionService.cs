using Server.Infrastructure;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Services
{
    public interface ITransactionService
    {
        /// <summary>
        /// Award 10 bonus rubles to card
        /// </summary>
        /// <param name="card">card to award</param>
        void AwardBonus(Card card);

        /// <summary>
        /// Currency exchange method
        /// </summary>
        /// <param name="moneytoExchange">money to exchange in currencyTaget</param>
        /// <param name="currencyTarget">currnecy to exchange</param>
        /// <returns>money value in currencyTarget</returns>
        decimal CurrencyExchange(Money moneytoExchange, CurrencyType currencyTarget);

    }
}
