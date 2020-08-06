using Meteoro.Corte.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Corte.API.Core.Interfaces
{
    public interface ICorteRepository
    {
        Task<int> Post(TbCorte entity);
        Task<int> Put(TbCorte entity);
        Task<IEnumerable<object>> Get();
        Task<TbCorte> GetById(TbCorte entity);
        Task<int> Delete(dynamic id);
    }
}
