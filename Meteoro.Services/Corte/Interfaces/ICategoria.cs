using Meteoro.Corte.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Corte.Interfaces
{
    public interface ICategoria
    {
        Task<IEnumerable<TbCategoria>> Get();
    }
}
