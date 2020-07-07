using Meteoro.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.API.Core.Interfaces
{
    public interface IModalidadRepository
    {
        Task<int> Post(Tblmodalidad entity);
        Task<int> Put(Tblmodalidad entity);
        Task<IEnumerable<Tblmodalidad>> Get();
        Task<Tblmodalidad> GetById(dynamic id);
        Task<int> Delete(dynamic id);
    }
}
