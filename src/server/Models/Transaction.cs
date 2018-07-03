using Server.Infrastructure;
using Server.Services;
using System;

namespace Server.Models
{
    public class Transaction
    {
        readonly ITransactionService service = new TransactionService();

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

        /// <summary>
        /// Execute transaction
        /// </summary>
        public void Execute()
        {
            // calculate withdraw and deposite value in card currencies
            decimal withdraw = service.CurrencyExchange(TransactionMoney, WriteOffCard.CardBalance.CurrencyType);
            decimal deposit = service.CurrencyExchange(TransactionMoney, WriteOnCard.CardBalance.CurrencyType);
            
            // check write off card balance
            decimal writeOffBalance = WriteOffCard.CardBalance.MoneyValue;
            // check writeoff card withdraw ability
            if (writeOffBalance - withdraw <= 0)
            {
                throw new Exception();
            }

            // do transfer
            WriteOffCard.CardBalance.MoneyValue -= withdraw;
            WriteOnCard.CardBalance.MoneyValue += deposit;
        }        
    }
}