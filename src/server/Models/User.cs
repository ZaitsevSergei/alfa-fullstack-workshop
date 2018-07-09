using Server.Exceptions;
using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace Server.Models
{
    /// <summary>
    /// User domain model
    /// </summary>
    public class User
    {
        private MailAddress _mail;

        /// <summary>
        /// Create new User
        /// </summary>
        /// <param name="userName">Login of the user</param>
        public User(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                throw new UserDataException("username is null or empty", userName);

            UserName = userName;
        }

        /// <summary>
        /// Identificator
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Getter and setter username of the user for login
        /// </summary>
        public string UserName
        {
            get => _mail.ToString();

            private set
            {
                try
                {
                    this._mail = new MailAddress(value);
                }
                catch (FormatException)
                {
                    throw new UserDataException("Email is invalid", value);
                }
            }
        }

        /// <summary>
        /// Getter and setter Surname of the user
        /// </summary>
        /// <returns><see langword="string"/></returns>
        public string Surname { get; set; }

        /// <summary>
        /// Getter and setter Firstname of the user
        /// </summary>
        /// <returns><see langword="string"/></returns>
        public string Firstname { get; set; }

        /// <summary>
        /// Getter and setter Middlename of the user
        /// </summary>
        /// <returns><see langword="string"/></returns>
        public string Middlename { get; set; }

        /// <summary>
        /// Getter and setter Bithday of the user
        /// </summary>
        /// <returns>Datetime</returns>
        public DateTime? Birthday { get; set; }

        /// <summary>
        /// Getter user card list
        /// </summary>
        public IList<Card> Cards { get; set; } = new List<Card>();
    }
}