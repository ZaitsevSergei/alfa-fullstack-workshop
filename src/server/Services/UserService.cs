using System;
using System.Net.Mail;

namespace Server.Services
{
    public class UserService
    {
        private MailAddress mail;
        public bool CheckUserName(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return false;

            try
            {
                mail = new MailAddress(userName);
            }
            catch (FormatException)
            {
                return false;
            }

            return true;
        }
    }
}
