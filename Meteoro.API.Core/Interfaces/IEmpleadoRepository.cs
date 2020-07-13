using Meteoro.Entities.Entities;
using Meteoro.Entities.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.API.Core.Interfaces
{
    public interface IEmpleadoRepository
    {
        Task<int> Post(Tblempleado entity);
        Task<int> Put(Tblempleado entity);
        Task<IEnumerable<EmpleadosListado>> Get();
        Task<Tblempleado> GetById(Tblempleado entity);
        Task<int> Delete(dynamic id);
        Task<Tblempleado> Login(Tblempleado entity); 
        
    }
}
