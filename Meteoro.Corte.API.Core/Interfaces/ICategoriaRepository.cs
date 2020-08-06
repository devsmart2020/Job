using Meteoro.Corte.Entities.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Corte.API.Core.Interfaces
{
    public interface ICategoriaRepository
    {
        Task<int> Post(TbCategoria entity);
        Task<int> Put(TbCategoria entity);
        Task<IEnumerable<TbCategoria>> Get();
        Task<TbCategoria> GetById(TbCategoria entity);
        Task<int> Delete(dynamic id);
    }
}
