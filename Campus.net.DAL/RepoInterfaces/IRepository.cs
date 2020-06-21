using System;
using System.Collections.Generic;

namespace Campus.net.DAL.RepoInterfaces
{
    public interface IRepository<T>
    {
        IReadOnlyCollection<T> GetAll();
        T GetOne(Guid id);
        void AddOne(T item);
        void UpdateOne(T item);
        void DeleteOne(Guid id);
        bool Exists(Guid id);
    }
}