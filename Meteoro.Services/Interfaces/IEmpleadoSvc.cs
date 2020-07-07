using Meteoro.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Interfaces
{
    public interface IEmpleadoSvc
    {
        Task<IEnumerable<Tblempleado>> Get();
        Task<Tblempleado> GetById(string url);
        Task<bool> Post(Tblempleado entity);
        Task<bool> PostList(List<Tblempleado> entities);
        Task<bool> Put(Tblempleado entity);
        Task<bool> Delete(dynamic id);
        Task<Tblempleado> Login(Tblempleado entity);
        


    }
}
