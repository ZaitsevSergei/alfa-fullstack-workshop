using Server.Infrastructure;
using Server.Models;
using Server.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ServerTest
{
    public class AddNewCardTests
    {
        readonly ITransactionService TransactionService = new TransactionService();

        #region Positive cases
        [Fact]
        public void ValidCardNumberAddedBonusTest()
        {
            Money balance = new Money(2000m, CurrencyType.RUB);
            Card card = new Card("5395029009021990", balance);
            TransactionService.AwardBonus(card);
            Assert.Equal(balance.MoneyValue + 10, card.CardBalance.MoneyValue);
        }

        public void ValidCardEURAddedBonusTest()
        {
            Money balance = new Money(2000m, CurrencyType.EUR);
            Card card = new Card("5395029009021990", balance);
            TransactionService.AwardBonus(card);
            decimal bonusInEUR = 10 * Constants.ExchangeRate["RUBEUR"];
            Assert.Equal(balance.MoneyValue + bonusInEUR, card.CardBalance.MoneyValue);
        }

        #endregion

        #region Negative cases
        [Fact]
        public void InvalidCardNumberAddedTest()
        {
            Money balance = new Money(2000m, CurrencyType.RUB);
            Card card = new Card("1395029009021990", balance);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void InvalidCardBalanceTest(decimal money)
        {
            Money balance = new Money(money, CurrencyType.RUB);

        }

        #endregion

    }
}
