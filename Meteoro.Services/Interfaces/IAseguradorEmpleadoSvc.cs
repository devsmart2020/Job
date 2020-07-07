using Meteoro.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Interfaces
{
    public interface IAseguradorEmpleadoSvc
    {
        Task<IEnumerable<Tblaseguradorempleado>> Get();
        Task<Tblaseguradorempleado> GetById(string url);
        Task<bool> Post(Tblaseguradorempleado entity);
        Task<bool> PostList(List<Tblaseguradorempleado> entities);
        Task<bool> Put(Tblaseguradorempleado entity);
        Task<bool> Delete(dynamic id);
    }
}
