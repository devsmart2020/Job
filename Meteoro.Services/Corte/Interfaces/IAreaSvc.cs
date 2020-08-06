using Meteoro.Corte.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Corte.Interfaces
{
    public interface IAreaSvc
    {
        Task<IEnumerable<TbArea>> Get();
        Task<TbArea> GetById(string url);
        Task<bool> Post(TbArea entity);
        Task<bool> PostList(List<TbArea> entities);
        Task<bool> Put(TbArea entity);
        Task<bool> Delete(dynamic id);
    }
}
