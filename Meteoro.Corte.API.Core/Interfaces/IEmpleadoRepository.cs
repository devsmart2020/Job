
using Meteoro.Corte.Entities.Entities;
using Meteoro.Corte.Entities.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Corte.API.Core.Interfaces
{
    public interface IEmpleadoRepository
    {
        Task<int> Post(TbEmpleado entity);
        Task<int> Put(TbEmpleado entity);
        Task<IEnumerable<EmpleadosListado>> Get();
        Task<TbEmpleado> GetById(TbEmpleado entity);
        Task<int> Delete(dynamic id);
        Task<TbEmpleado> Login(TbEmpleado entity); 
        
    }
}
