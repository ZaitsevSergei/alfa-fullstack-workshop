
using System.Linq;
using Server.Models;
using Microsoft.EntityFrameworkCore;
using Server.Exceptions;
using Server.Infrastructure;

namespace Server.Core
{
    public class SQLContext : DbContext
    {
        public SQLContext()
            : base()
        { }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=AlfaDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public User CurrentUser { get; set; }

    }
}