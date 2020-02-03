using System;
using System.Collections.Generic;
using System.Text;

namespace Campus.net.DAL
{
    public interface IRepository<T>
    {
        void AddOne(T item);//test
        T GetOne(Guid id);//любой коммент
        IReadOnlyCollection<T> GetAll();//Comment
        void UpdateOne(T item);//hui
        void DeleteOne(T item);
    }
}
