using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace coffeestore_online.IRepository
{
    public interface IRepository<T>
    {
        List<T> List();
        T Get(string id);
        void Insert(T item);
        void Delete(string id);
        void Update(T item, string id);
        T convertToModel(T item);
    }
}