using Server.Exceptions;
using Server.Infrastructure;
using Server.Services;
using System;

namespace Server.Models
{
    public class Transaction
    {
        readonly ITransactionService transactionService = new TransactionService();
        readonly ICardService cardService = new CardService();

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
            // validate cards activity
            if(!cardService.ValidateCardActivity(WriteOffCard))
            {
                throw new CardActitvityException(WriteOffCard.CardNumber, WriteOffCard.ExpirityDate);
            }
            if (!cardService.ValidateCardActivity(WriteOnCard))
            {
                throw new CardActitvityException(WriteOnCard.CardNumber, WriteOnCard.ExpirityDate);
            }
            
            // Validate write off card balance
            decimal withdraw = cardService.ValidateCardBalance(WriteOffCard, TransactionMoney);

            // calculate deposit sum
            decimal deposit = transactionService.CurrencyExchange(TransactionMoney, 
                WriteOnCard.CardBalance.CurrencyType);
                       
            // do transfer
            WriteOffCard.CardBalance.MoneyValue -= withdraw;
            WriteOnCard.CardBalance.MoneyValue += deposit;
        }        
    }
}