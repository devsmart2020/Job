
using Meteoro.Corte.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Corte.API.Core.Interfaces
{
    public interface IAdminRepository
    {
        Task<int> Post(TbAdmin entity);
        Task<int> Put(TbAdmin entity);
        Task<IEnumerable<TbAdmin>> Get();
        Task<TbAdmin> GetById(dynamic id);
        Task<int> Delete(dynamic id);
    }
}
