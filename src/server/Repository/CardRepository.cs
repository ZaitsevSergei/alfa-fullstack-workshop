using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Server.Core;
using Server.Models;

namespace Server.Repository
{
    public class CardRepository : IRepository<Card>
    {
        private readonly SQLContext context;
        private bool disposed;


        public CardRepository(SQLContext context)
        {
            this.context = context;
        }

        public IEnumerable<Card> GetAll()
        {
            return context.Cards.ToList();
        }

        public Card GetById(int id)
        {
            return context.Cards.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Get one card by cardNumber. Must be with populating balance
        /// </summary>
        /// <param name="cardNumber">cardNumber of the cards</param>
        /// <returns><see cref="Card"/> instance</returns>
        public dynamic GetByNumber(string cardNumber, int skip)
        {
            return context.CurrentUser.Cards.FirstOrDefault(x => x.CardNumber == cardNumber);
        }

        public void Create(Card item)
        {
            context.Cards.Add(item);
            context.SaveChanges();
        }

        public void Update(Card item)
        {
            Card card = GetByNumber(item.CardNumber);
            card = item;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.CurrentUser.Cards.Remove(GetById(id));
        }
        

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
