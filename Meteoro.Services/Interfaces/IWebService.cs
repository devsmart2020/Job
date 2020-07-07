using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Interfaces
{
    public interface IWebService<T>
    {
        Task<IEnumerable<T>> GetAsync(string url);
        Task<T> GetByIdAsync(string url);
        Task<bool> PostAsync(T entity, string url);
        Task<bool> PutAsync(T entity, string url);
        Task<bool> DeleteAsync(string url);
    }
}
