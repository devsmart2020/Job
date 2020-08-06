using Meteoro.Corte.Entities.Entities;
using Meteoro.Corte.Entities.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Corte.Interfaces
{
    public interface IEmpleadoSvc
    {
        Task<IEnumerable<EmpleadosListado>> Get();
        Task<TbEmpleado> GetById(TbEmpleado entity);
        Task<bool> Post(TbEmpleado entity);
        Task<bool> PostList(List<TbEmpleado> entities);
        Task<bool> Put(TbEmpleado entity);
        Task<bool> Delete(dynamic id);
        Task<TbEmpleado> Login(TbEmpleado entity);
        


    }
}
