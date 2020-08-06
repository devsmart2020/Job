using Meteoro.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Interfaces
{
    public interface IAdminSvc
    {
        Task<IEnumerable<Tbladmin>> Get();
        Task<Tbladmin> GetById(string url);
        Task<bool> Post(Tbladmin entity);
        Task<bool> PostList(List<Tbladmin> entities);
        Task<bool> Put(Tbladmin entity);
        Task<bool> Delete(dynamic id);
    }
}
