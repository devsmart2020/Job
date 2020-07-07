using Meteoro.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.API.Core.Interfaces
{
    public interface IRegistroRepository
    {
        Task<int> Post(Tblregistro entity);
        Task<int> Put(Tblregistro entity);
        Task<IEnumerable<Tblregistro>> Get();
        Task<Tblregistro> GetById(dynamic id);
        Task<int> Delete(dynamic id);
    }
}
