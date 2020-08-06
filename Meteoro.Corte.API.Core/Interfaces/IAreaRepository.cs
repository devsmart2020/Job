
using Meteoro.Corte.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Corte.API.Core.Interfaces
{
    public interface IAreaRepository
    {
        Task<int> Post(TbArea entity);
        Task<int> Put(TbArea entity);
        Task<IEnumerable<TbArea>> Get();
        Task<TbArea> GetById(dynamic id);
        Task<int> Delete(dynamic id);
    }

 
}
