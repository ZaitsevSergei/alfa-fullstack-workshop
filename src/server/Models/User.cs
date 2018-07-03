using Server.Exceptions;
using Server.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Server.Models
{
    /// <summary>
    /// User domain model
    /// </summary>
    public class User
    {
        public User(int userId, string userName)
        {
            // TODO return own Exception class
            if (string.IsNullOrWhiteSpace(userName)) throw new UserDataException("username is null or empty", userName);            

            UserId = userId;
            UserName = userName;
        }

        /// <summary>
        /// User id in database
        /// </summary>
        public int UserId { get; private set; }

        /// <summary>
        /// Getter and setter username of the user for login
        /// </summary>
        public string UserName { get; private set; }

        /// <summary>
        /// Path to user avatar picture
        /// </summary>
        public string UserAvatar { get; set; }

        /// <summary>
        /// Getter user card list
        /// </summary>
        public List<Card> Cards { get; } = new List<Card>();

        /// <summary>
        /// Added new card to list
        /// </summary>
        /// <param name="shortCardName"></param>
        public Card AddOpenNewCard(string shortCardName)
        {
            Card card = new Card(2, "4083967629457310", shortCardName, new Money(300000, CurrencyType.USD),
                new DateTime(2023, 04, 24), CardUseType.Debit, CardType.VISA, this);

            Cards.Add(card);
            return card;
        }
    }
}