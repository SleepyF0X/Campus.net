using System;
using System.Collections.Generic;

namespace Campus.net.DAL
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