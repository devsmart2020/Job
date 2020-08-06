using Meteoro.Corte.Entities.Entities;
using Meteoro.Services.Corte.Data;
using Meteoro.Services.Corte.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Corte.Services
{
    public class CorteSvc : ICorteSvc
    {
        private protected readonly string RutaApi = "api/Cortes/";

        public Task<bool> Delete(dynamic id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TbCorte>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<TbCorte> GetById(TbCorte entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Post(TbCorte entity)
        {
            WebService<TbCorte>.InitializeClient();
            return await WebService<TbCorte>.PostAsync(entity, RutaApi);
        }

        public Task<bool> PostList(List<TbCorte> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Put(TbCorte entity)
        {
            throw new NotImplementedException();
        }
    }
}
