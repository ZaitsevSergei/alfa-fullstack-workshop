using System.Collections.Generic;
using Server.Infrastructure;
using Server.Models;

namespace Server.Data
{
    /// <summary>
    /// Generic repository for current user
    /// </summary>
    public interface IBankRepository
    {
        /// <summary>
        /// Getter for cards
        /// </summary>
        IEnumerable<Card> GetCards();

        /// <summary>
        /// Get one card by number
        /// </summary>
        /// <param name="cardNumber">number of the cards</param>
        Card GetCard(string cardNumber);

        /// <summary>
        /// OpenNewCard 
        /// </summary>
        /// <param name="currency">card currency</param>
        /// <param name="cardType">type of the cards</param>
        /// <param name="shortCardName">name of card</param>
        void OpenNewCard(string shortCardName, Currency currency, CardType cardType);
        

        /// <summary>
        /// Transfer money
        /// </summary>
        /// <param name="sum">sum of operation</param>
        /// <param name="from">card number</param>
        /// <param name="to">card number</param>
        void TransferMoney(decimal sum, string from, string to);

        /// <summary>
        /// Get range of transactions
        /// </summary>
        /// <param name="cardnumber"></param>
        /// <param name="from">from range</param>        
        IEnumerable<Transaction> GetTranasctions(string cardNumber, int from);

        /// <summary>
        /// Get current logged user
        /// </summary>
        User GetCurrentUser();
    }
}