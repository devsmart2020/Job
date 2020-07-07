using Meteoro.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.API.Core.Interfaces
{
    public interface IAdminRepository
    {
        Task<int> Post(Tbladmin entity);
        Task<int> Put(Tbladmin entity);
        Task<IEnumerable<Tbladmin>> Get();
        Task<Tbladmin> GetById(dynamic id);
        Task<int> Delete(dynamic id);
    }
}
