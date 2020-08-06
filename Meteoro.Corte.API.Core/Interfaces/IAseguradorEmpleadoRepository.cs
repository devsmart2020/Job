
using Meteoro.Corte.Entities.Entities;
using Meteoro.Corte.Entities.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Corte.API.Core.Interfaces
{
    public interface IAseguradorEmpleadoRepository
    {
        Task<int> Post(TbAseguradorEmpleado entity);
        Task<int> Put(TbAseguradorEmpleado entity);
        Task<IEnumerable<TbAseguradorEmpleado>> Get();
        Task<TbAseguradorEmpleado> GetById(dynamic id);
        Task<int> Delete(dynamic id);
        Task<bool> AsignarCosechadores(int revisiones);
        Task<IEnumerable<AseguradorEmpleadoListado>> ListarCosechadoresAsignados();
    }
}
