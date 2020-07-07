using Meteoro.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.API.Core.Interfaces
{
    public interface ISemanaRepository
    {
        Task<int> Post(Tblsemana entity);
        Task<int> Put(Tblsemana entity);
        Task<IEnumerable<Tblsemana>> Get();
        Task<Tblsemana> GetById(dynamic id);
        Task<int> Delete(dynamic id);
    }
}
