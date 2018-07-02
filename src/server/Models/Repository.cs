using System;
using System.Collections.Generic;
using System.Text;

namespace Server.Models
{
    public static class Repository
    {
        public static List<User> Users { get; set; } = new List<User>();
        public static List<Card> Cards { get; set; } = new List<Card>();
        public static List<Transaction> Transactions { get; set; } = new List<Transaction>();
    }
}
