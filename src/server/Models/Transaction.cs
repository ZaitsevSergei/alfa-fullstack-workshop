using Server.Infrastructure;
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
        /// Value of transaction
        /// </summary>
        public decimal TransactionValue { get; private set; }

        /// <summary>
        /// Currency of transaction
        /// </summary>
        public CurrencyType TransactionCurrency { get; private set; }

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

    }
}