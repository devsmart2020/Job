using Meteoro.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Interfaces
{
    public interface IModalidadSvc
    {
        Task<IEnumerable<Tblmodalidad>> Get();
        Task<Tblmodalidad> GetById(string url);
        Task<bool> Post(Tblmodalidad entity);
        Task<bool> PostList(List<Tblmodalidad> entities);
        Task<bool> Put(Tblmodalidad entity);
        Task<bool> Delete(dynamic id);
    }
}
