using Meteoro.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.API.Core.Interfaces
{
    public interface IAseguradorEmpleadoRepository
    {
        Task<int> Post(Tblaseguradorempleado entity);
        Task<int> Put(Tblaseguradorempleado entity);
        Task<IEnumerable<Tblaseguradorempleado>> Get();
        Task<Tblaseguradorempleado> GetById(dynamic id);
        Task<int> Delete(dynamic id);
    }
}
