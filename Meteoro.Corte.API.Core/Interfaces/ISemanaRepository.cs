using Meteoro.Corte.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Corte.API.Core.Interfaces
{
    public interface ISemanaRepository
    {
        Task<int> Post(TbSemana entity);
        Task<int> Put(TbSemana entity);
        Task<IEnumerable<TbSemana>> Get();
        Task<TbSemana> GetById(dynamic id);
        Task<int> Delete(dynamic id);
    }
}
