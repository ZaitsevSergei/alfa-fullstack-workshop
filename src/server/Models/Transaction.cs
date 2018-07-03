﻿using Server.Infrastructure;
using System;

namespace Server.Models
{
    public class Transaction
    {
        /// <summary>
        /// Transaction id in database
        /// </summary>
        public int TransactionId { get; private set; }

        /// <summary>
        /// Date of transaction
        /// </summary>
        public DateTime TransactionDate { get; private set; }

        /// <summary>
        /// Money transfer
        /// </summary>
        public Money TransactionMoney { get; }

        /// <summary>
        /// Write off card
        /// </summary>
        public Card WriteOffCard { get; set; }

        /// <summary>
        /// Write on card
        /// </summary>
        public Card WriteOnCard { get; set; }

        public Transaction(int transactionId, DateTime transactionDate, Money transactionMoney, Card writeOffCard, Card writeOnCard)
        {
            TransactionId = transactionId;
            TransactionDate = transactionDate;
            TransactionMoney = transactionMoney;
            WriteOffCard = writeOffCard;
            WriteOnCard = writeOnCard;
        }

        public void Execute()
        {
            // init coefficients to write off and write on cards
            decimal writeOffCoeficient = CalculateExchangeCoeffiecients(WriteOffCard.CardBalance.CurrencyType);
            decimal writeOnCoeficient = CalculateExchangeCoeffiecients(WriteOnCard.CardBalance.CurrencyType); ;

            // check write off card balance
            decimal writeOffBalance = WriteOffCard.CardBalance.MoneyValue;
            decimal withdraw = TransactionMoney.MoneyValue * writeOffCoeficient;
            // check writeoff card withdraw ability
            if (writeOffBalance - withdraw <= 0)
            {
                throw new Exception();
            }

            // do transfer
            WriteOffCard.CardBalance.MoneyValue -= withdraw;
            WriteOnCard.CardBalance.MoneyValue += TransactionMoney.MoneyValue * writeOnCoeficient;
        }

        private decimal CalculateExchangeCoeffiecients(CurrencyType type)
        {
            if (TransactionMoney.CurrencyType == type)
            {
                return 1;
            }
            else
            {
                return Constants.ExchangeRate[TransactionMoney.CurrencyType.ToString("G") +
                    type.ToString("G")];
            }
        }
    }
}