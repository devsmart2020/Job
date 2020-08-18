using Meteoro.Corte.Entities.Entities;
using Meteoro.Services.Corte.Data;
using Meteoro.Services.Corte.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Corte.Services
{
    public class SemanaSvc : ISemanaSvc
    {
        private readonly string RutaApi = "api/Semanas/";

        public async Task<TbSemana> Get(TbSemana entity)
        {
            WebService<TbSemana>.InitializeClient();
            return await WebService<TbSemana>.GetPostEntity($"{RutaApi}SemanaActual", entity);
        }

        public async Task<IEnumerable<TbSemana>> GetSemanas()
        {
            WebService<TbSemana>.InitializeClient();
            return await WebService<TbSemana>.GetAsync(RutaApi);
        }

        
    }
}
