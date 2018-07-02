using Server.Infrastructure;
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

        public static Card AlfaBank = new Card(1, "5395029009021990", "alfabankCard",
            new Money(1000000000m, CurrencyType.RUB), new DateTime(2023, 12, 31), CardUseType.Debit,
            CardType.VISA, new User(1, "AlfaBank"));

    }
}
