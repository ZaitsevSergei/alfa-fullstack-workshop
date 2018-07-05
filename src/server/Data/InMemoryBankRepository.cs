using System;
using System.Collections.Generic;
using System.Linq;
using Server.Exceptions;
using Server.Infrastructure;
using Server.Models;
using Server.Services;

namespace Server.Data
{
    /// <summary>
    /// Base implementation for onMemory Storage
    /// </summary>
    public class InMemoryBankRepository : IBankRepository
    {
        private readonly User currentUser;

        ICardService cardService = new CardService();
        IBusinessLogicService bService = BusinessLogicService();

        public InMemoryBankRepository()
        {
            currentUser = FakeDataGenerator.GenerateFakeUser();
            FakeDataGenerator.GenerateFakeCardsToUser(currentUser);
            //TODO other fakes
        }

        /// <summary>
        /// Get one card by number
        /// </summary>
        /// <param name="cardNumber">number of the cards</param>
        public Card GetCard(string cardNumber)
        {
            try
            {
                return currentUser.Cards.First(x => x.CardNumber == cardService.CreateNormalizeCardNumber(cardNumber));
            }
            catch (Exception)
            {

                throw new BusinessLogicException(TypeBusinessException.CARD, "User hasn't card with this number", cardNumber);
            }
            
        }

        /// <summary>
        /// Getter for cards
        /// </summary>
        public IEnumerable<Card> GetCards() {
            return GetCurrentUser().Cards;
        }
        /// <summary>
        /// Get current logged user
        /// </summary>
        public User GetCurrentUser()
            => currentUser == null ? currentUser : throw new BusinessLogicException(TypeBusinessException.USER, "User is null");

        /// <summary>
        /// Get range of transactions
        /// </summary>
        /// <param name="cardnumber"></param>
        /// <param name="from">from range</param>        
        public IEnumerable<Transaction> GetTranasctions(string cardnumber, int from)
        {
            var card = GetCard(cardnumber);
            if (from < 0)
                throw new BusinessLogicException(TypeBusinessException.TRANSACTION, "From value must be greather than 0");
            return card.Transactions.Skip(from).Take(10);
        }
               

        /// <summary>
        /// OpenNewCard
        /// </summary>
        /// <param name="cardType">type of the cards</param>
        public void OpenNewCard(string shortCardName, Currency currency, CardType cardType)
        {
            currentUser.OpenNewCard(shortCardName, currency, cardType);
        }

        /// <summary>
        /// Transfer money
        /// </summary>
        /// <param name="sum">sum of operation</param>
        /// <param name="from">card number</param>
        /// <param name="to">card number</param>
        public void TransferMoney(decimal sum, string from, string to)
        {
            Card fromCard, toCard;
            // find cards
            if ((fromCard = currentUser.Cards.FirstOrDefault(x => x.CardNumber == cardService.
                        CreateNormalizeCardNumber(from))) == null)
            {
                throw new BusinessLogicException(TypeBusinessException.CARD, "Card doesn't exists", from); 
            }

            if ((toCard = currentUser.Cards.FirstOrDefault(x => x.CardNumber == cardService.
                        CreateNormalizeCardNumber(to))) == null)
            {
                throw new BusinessLogicException(TypeBusinessException.CARD, "Card doesn't exists", to);
            }

            if(bService.GetBalanceOfCard(fromCard) - sum < 0)
            {
                throw new BusinessLogicException(TypeBusinessException.TRANSACTION, $"Balance is less than sum of transfer", to);
            }

            fromCard.AddTransaction(new Transaction(sum, fromCard, toCard));
            toCard.AddTransaction(new Transaction(sum, fromCard, toCard));
        }
    }
}