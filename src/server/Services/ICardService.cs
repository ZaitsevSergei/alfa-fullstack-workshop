using Server.Infrastructure;
using Server.Models;

namespace Server.Services
{
    /// <summary>
    /// Interface for checking numbers and extracting card types
    /// </summary>
    public interface ICardService
    {
        /// <summary>
        /// Check card number by Lun algoritm
        /// </summary>
        /// <param name="number">card number in any format</param>
        /// <returns>Return <see langword="true"/> if card is valid</returns>
        bool CheckCardNumber(string number);

        /// <summary>
        /// Check card number by Alfabank emmiter property
        /// </summary>
        /// <param name="number">card number in any format</param>
        /// <returns>Return <see langword="true"/> if card was emmited in Alfabank </returns>
        bool CheckCardEmmiter(string number);

        /// <summary>
        /// Extract card number
        /// </summary>
        /// <param name="number">card number in any format</param>
        /// <returns>Return 0 is card is invalid, 1 if card is mastercard, 2 is visa, 3 is maestro, 4 is visa electon</returns>
        int CardTypeExtract(string number);

        /// <summary>
        /// Check card activity by expiration date
        /// </summary>
        /// <param name="card">card to validate</param>
        /// <returns></returns>
        bool ValidateCardActivity(Card card);

        /// <summary>
        /// Check card able to do withdraw
        /// </summary>
        /// <param name="card">card to check</param>
        /// <param name="withdraw">money to withdraw</param>
        /// <returns></returns>
        bool ValidateCardBalance(Card card, Money withdraw);



    }
}