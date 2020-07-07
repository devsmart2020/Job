using Meteoro.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.API.Core.Interfaces
{
    public interface IEmpresaRepository
    {
        Task<int> Post(Tblempresa entity);
        Task<int> Put(Tblempresa entity);
        Task<IEnumerable<Tblempresa>> Get();
        Task<Tblempresa> GetById(dynamic id);
        Task<int> Delete(dynamic id);
    }
}
