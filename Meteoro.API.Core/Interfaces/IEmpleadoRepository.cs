using Meteoro.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.API.Core.Interfaces
{
    public interface IEmpleadoRepository
    {
        Task<int> Post(Tblempleado entity);
        Task<int> Put(Tblempleado entity);
        Task<IEnumerable<Tblempleado>> Get();
        Task<Tblempleado> GetById(dynamic id);
        Task<int> Delete(dynamic id);
        Task<Tblempleado> Login(Tblempleado entity); 
        
    }
}
