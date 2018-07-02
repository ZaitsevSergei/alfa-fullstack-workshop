using Server.Infrastructure;
using Server.Services;
using System;
using System.Collections.Generic;

namespace Server.Models
{
    /// <summary>
    /// Card domain model
    /// </summary>
    public class Card
    {
        private readonly ICardService cardService = new CardService();

        public Card(string cardNumber, string cardName)
        {
            //TODO validation
            CardNumber = cardNumber;
            CardName = cardName;
        }

        /// <summary>
        /// Card number. Set only from constructor.
        /// </summary>
        /// <returns>string card number representation</returns>
        public string CardNumber { get; private set; }

        /// <summary>
        /// Short name of the cards
        /// </summary>
        /// <returns></returns>
        public string CardName { get; set; }

        /// <summary>
        /// Card id in database
        /// </summary>
        public int CardId { get; private set; }

        // TODO add fields

        /// <summary>
        /// Card balance
        /// </summary>
        public decimal CardBalance { get; private set; }

        /// <summary>
        /// expirity date of card
        /// </summary>
        public DateTime ExpirityDate { get; private set; }

        /// <summary>
        /// type of card: debit or credit
        /// </summary>
        public CardUseType CardUseType { get; private set; }

        /// <summary>
        /// card payment system
        /// </summary>
        public CardType CardPaymentSystemType { get; set; }

        /// <summary>
        /// Card holder
        /// </summary>
        public User User { get; private set; }

        /// <summary>
        /// Transaction by this card
        /// </summary>
        public ICollection<Transaction> Transactions { get; set; }
    }
}