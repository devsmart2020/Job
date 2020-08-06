using Meteoro.Corte.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Corte.Interfaces
{
    public interface IEmpresaSvc
    {
        Task<IEnumerable<TbEmpresa>> Get();
        Task<TbEmpresa> GetById(string url);
        Task<bool> Post(TbEmpresa entity);
        Task<bool> PostList(List<TbEmpresa> entities);
        Task<bool> Put(TbEmpresa entity);
        Task<bool> Delete(dynamic id);
    }
}
