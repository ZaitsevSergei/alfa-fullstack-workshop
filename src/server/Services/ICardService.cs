using Server.Infrastructure;

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
        /// <returns>Return enum CardType</returns>
        CardType CardTypeExtract(string number);

        /// <summary>
        /// Utils method
        /// </summary>
        /// <param name="cardNumber">card number in any format</param>
        /// <returns>Digits of a card number </returns>
        string CreateNormalizeCardNumber(string cardNumber);

        /// <summary>
        /// Converts int cardType value to <see cref="CardType"/> if it's possible
        /// </summary>
        /// <param name="cardType">card type integer value</param>
        /// <returns></returns>
        CardType ValidateCardType(int cardType);

        /// <summary>
        /// Converts int currency value to <see cref="Currency"/> if it's possible
        /// </summary>
        /// <param name="currencyInput">currency integer value</param>
        /// <returns></returns>
        Currency ValidateCurrency(int currencyInput);
    }
}