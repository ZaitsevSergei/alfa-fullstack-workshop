using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Core;
using Server.Models;

namespace Server.Repository
{
    public class CardRepository : IRepository<Card>
    {
        private readonly SQLContext context;
        private bool disposed = false;


        public CardRepository(SQLContext context)
        {
            this.context = context;
        }

        public IEnumerable<Card> GetAll()
        {
            throw new NotImplementedException();
        }

        public Card GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Create(Card item)
        {
            throw new NotImplementedException();
        }

        public void Update(Card item)
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
