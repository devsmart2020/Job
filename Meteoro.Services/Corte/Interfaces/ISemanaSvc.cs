using Meteoro.Corte.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Corte.Interfaces
{
    public interface ISemanaSvc
    {
        Task<TbSemana> Get(TbSemana entity);
        Task<IEnumerable<TbSemana>> GetSemanas();
    }
}
