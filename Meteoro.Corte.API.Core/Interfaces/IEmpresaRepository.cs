
using Meteoro.Corte.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Corte.API.Core.Interfaces
{
    public interface IEmpresaRepository
    {
        Task<int> Post(TbEmpresa entity);
        Task<int> Put(TbEmpresa entity);
        Task<IEnumerable<TbEmpresa>> Get();
        Task<TbEmpresa> GetById(dynamic id);
        Task<int> Delete(dynamic id);
    }
}
