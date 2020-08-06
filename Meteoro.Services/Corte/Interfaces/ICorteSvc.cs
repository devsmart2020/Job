using Meteoro.Corte.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Corte.Interfaces
{
    public interface ICorteSvc
    {
        Task<IEnumerable<TbCorte>> Get();
        Task<TbCorte> GetById(TbCorte entity);
        Task<bool> Post(TbCorte entity);
        Task<bool> PostList(List<TbCorte> entities);
        Task<bool> Put(TbCorte entity);
        Task<bool> Delete(dynamic id);  
    }
}
