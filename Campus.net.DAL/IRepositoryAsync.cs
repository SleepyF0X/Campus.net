using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Campus.net.DAL
{
    public interface IRepositoryAsync<T>
    {
        Task AddOneAsync(T item);
        Task<T> GetOneAsync(Guid id);
        Task<IReadOnlyCollection<T>> GetAllAsync();
        Task UpdateOneAsync(T item);
        Task DeleteOneAsync(T item);
    }
}
