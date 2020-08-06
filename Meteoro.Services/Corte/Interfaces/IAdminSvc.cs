using Meteoro.Corte.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Corte.Interfaces
{
    public interface IAdminSvc
    {
        Task<IEnumerable<TbAdmin>> Get();
        Task<TbAdmin> GetById(string url);
        Task<bool> Post(TbAdmin entity);
        Task<bool> PostList(List<TbAdmin> entities);
        Task<bool> Put(TbAdmin entity);
        Task<bool> Delete(dynamic id);
    }
}
