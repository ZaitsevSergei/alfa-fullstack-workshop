using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Core;
using Server.Models;

namespace Server.Repository
{
    public class UnitOfWork : IDisposable
    {
        private SQLContext context = new SQLContext();
        private IRepository<Card> cardRepository;
        private IRepository<Transaction> transactionRepository;
        private bool disposed;
        public IRepository<Card> CardRepository
        {
            get
            {
                if (cardRepository != null)
                {
                    cardRepository = new CardRepository(context);
                }
                return cardRepository;

            }
            set => cardRepository = value;
        }

        public IRepository<Transaction> TransactionRepository
        {
            get
            {
                if (transactionRepository != null)
                {
                    transactionRepository = new TransactionRepository(context);
                }
                return transactionRepository;
            }
            set => transactionRepository = value;
        }

        public void Save()
        {
            context.SaveChanges();
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
