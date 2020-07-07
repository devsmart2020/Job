using Meteoro.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Interfaces
{
    public interface ICosechaSvc
    {
        Task<IEnumerable<Tblcosecha>> Get();
        Task<Tblcosecha> GetById(string url);
        Task<bool> Post(Tblcosecha entity);
        Task<bool> PostList(List<Tblcosecha> entities);
        Task<bool> Put(Tblcosecha entity);
        Task<bool> Delete(dynamic id);
    }
}
