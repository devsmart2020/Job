using Meteoro.Entities.Entities;
using Meteoro.Entities.Helpers;
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
        Task<bool> AsignarCosechadores(int revisiones);
        Task<IEnumerable<AseguradorEmpleadoListado>> ListarCosechadoresAsignados(IEnumerable<AseguradorEmpleadoListado> entity);
    }
}
