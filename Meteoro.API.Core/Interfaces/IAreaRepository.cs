using Meteoro.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.API.Core.Interfaces
{
    public interface IAreaRepository
    {
        Task<int> Post(Tblarea entity);
        Task<int> Put(Tblarea entity);
        Task<IEnumerable<Tblarea>> Get();
        Task<Tblarea> GetById(dynamic id);
        Task<int> Delete(dynamic id);
    }

 
}
