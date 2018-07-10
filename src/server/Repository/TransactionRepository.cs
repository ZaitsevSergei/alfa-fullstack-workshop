using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Core;
using Server.Models;

namespace Server.Repository
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private bool disposed;
        private SQLContext context;

        public TransactionRepository(SQLContext context)
        {
            this.context = context;
        }

        public IEnumerable<Transaction> GetAll()
        {
            throw new NotImplementedException();
        }

        public Transaction GetById(int id)
        {
            throw new NotImplementedException();
        }


        public dynamic GetByNumber(string cardNumber, int skip)
        {
            return context.Cards.FirstOrDefault(x => x.CardNumber == cardNumber).Transactions.Skip(skip).Take(10);
            
        }

        public void Create(Transaction item)
        {
            throw new NotImplementedException();
        }

        public void Update(Transaction item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
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
