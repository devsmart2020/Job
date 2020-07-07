using Meteoro.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Interfaces
{
    public interface IEmpresaSvc
    {
        Task<IEnumerable<Tblempresa>> Get();
        Task<Tblempresa> GetById(string url);
        Task<bool> Post(Tblempresa entity);
        Task<bool> PostList(List<Tblempresa> entities);
        Task<bool> Put(Tblempresa entity);
        Task<bool> Delete(dynamic id);
    }
}
