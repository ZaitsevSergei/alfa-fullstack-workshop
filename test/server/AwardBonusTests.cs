using Server.Infrastructure;
using Server.Models;
using Server.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ServerTest
{
    public class AwardBonusTests
    {
        ITransactionService TransactionService = new TransactionService();

        [Fact]
        public void ValidCardNumberCreated()
        {
            Money balance = new Money(2000m, CurrencyType.RUB);
            Card card = new Card("5395029009021990", balance);
            TransactionService.AwardBonus(card);
            Assert.Equal(balance.MoneyValue + 10, card.CardBalance.MoneyValue);
        }
    }
}
