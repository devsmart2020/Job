using Meteoro.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Interfaces
{
    public interface IAreaSvc
    {
        Task<IEnumerable<Tblarea>> Get();
        Task<Tblarea> GetById(string url);
        Task<bool> Post(Tblarea entity);
        Task<bool> PostList(List<Tblarea> entities);
        Task<bool> Put(Tblarea entity);
        Task<bool> Delete(dynamic id);
    }
}
