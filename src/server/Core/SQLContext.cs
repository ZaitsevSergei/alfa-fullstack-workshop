
using Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Server.Core
{
    public class SQLContext : DbContext
    {
        public SQLContext()
            : base()
        { }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}