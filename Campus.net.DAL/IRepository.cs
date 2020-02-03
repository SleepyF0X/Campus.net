using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL
{
    public interface IRepository<T>
    {
        void AddOne(T item);//test
        T GetOne(Guid id);
        IReadOnlyCollection<T> GetAll();//Comment
        void UpdateOne(T item);
        void DeleteOne(T item);
    }
}
