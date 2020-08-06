using Meteoro.Entities.Entities;
using Meteoro.Entities.Helpers;
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
        Task<bool> AsignarCosechadores(int revisiones);
        Task<IEnumerable<AseguradorEmpleadoListado>> ListarCosechadoresAsignados();
    }
}
