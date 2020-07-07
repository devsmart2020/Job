using Meteoro.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.API.Core.Interfaces
{
    public interface ICosechaRepository
    {
        Task<int> Post(Tblcosecha entity);
        Task<int> Put(Tblcosecha entity);
        Task<IEnumerable<Tblcosecha>> Get();
        Task<Tblcosecha> GetById(dynamic id);
        Task<int> Delete(dynamic id);
    }
}
