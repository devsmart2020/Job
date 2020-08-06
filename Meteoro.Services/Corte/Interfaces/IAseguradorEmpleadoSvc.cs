using Meteoro.Corte.Entities.Entities;
using Meteoro.Corte.Entities.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Corte.Interfaces
{
    public interface IAseguradorEmpleadoSvc
    {
        Task<IEnumerable<TbAseguradorEmpleado>> Get();
        Task<TbAseguradorEmpleado> GetById(string url);
        Task<bool> Post(TbAseguradorEmpleado entity);
        Task<bool> PostList(List<TbAseguradorEmpleado> entities);
        Task<bool> Put(TbAseguradorEmpleado entity);
        Task<bool> Delete(dynamic id);
        Task<bool> AsignarCosechadores(int revisiones);
        Task<TbAseguradorEmpleado> ObtenerIdRevision(TbAseguradorEmpleado entity);
        Task<bool> ActualizarRevision(TbAseguradorEmpleado entity);
        Task<IEnumerable<AseguradorEmpleadoListado>> ListarCosechadoresAsignados(IEnumerable<AseguradorEmpleadoListado> entity);
    }
}
