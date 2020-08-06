using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Corte.Interfaces
{
    public interface IWebService<T>
    {
        Task<IEnumerable<T>> GetAsync(string url);
        Task<T> GetByIdAsync(T entity);
        Task<bool> PostAsync(T entity, string url);
        Task<bool> PutAsync(T entity, string url);
        Task<bool> DeleteAsync(string url);
    }
}
