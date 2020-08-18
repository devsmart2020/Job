using Meteoro.Corte.Entities.Entities;
using Meteoro.Services.Corte.Data;
using Meteoro.Services.Corte.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Corte.Services
{
    public class CategoriaSvc : ICategoria
    {
        private protected readonly string RutaApi = "api/Categorias/";

        public async Task<IEnumerable<TbCategoria>> Get()
        {
            WebService<TbCategoria>.InitializeClient();
            return await WebService<TbCategoria>.GetAsync(RutaApi);
        }
    }
}
