using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL.DALServices
{
    public interface IRepository<T>
    {
        void AddOne(T item);
        T GetOne(Guid id);
        IReadOnlyCollection<T> GetAll();
        void UpdateOne(T item);
        void DeleteOne(T item);
    }
}
