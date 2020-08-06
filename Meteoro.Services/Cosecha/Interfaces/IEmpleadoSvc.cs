using Meteoro.Entities.Entities;
using Meteoro.Entities.Helpers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Meteoro.Services.Interfaces
{
    public interface IEmpleadoSvc
    {
        Task<IEnumerable<EmpleadosListado>> Get();
        Task<Tblempleado> GetById(Tblempleado entity);
        Task<bool> Post(Tblempleado entity);
        Task<bool> PostList(List<Tblempleado> entities);
        Task<bool> Put(Tblempleado entity);
        Task<bool> Delete(dynamic id);
        Task<Tblempleado> Login(Tblempleado entity);
        


    }
}
