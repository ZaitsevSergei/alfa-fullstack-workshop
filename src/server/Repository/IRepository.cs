using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Repository
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        dynamic GetByNumber(string cardNumber, int skip);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
