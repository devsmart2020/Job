using Meteoro.Corte.Entities.Entities;
using Meteoro.Services.Corte.Interfaces;
using Meteoro.Services.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Corte.Services
{
    public class AreaSvc : IAreaSvc
    {
        private readonly string RutaApi = "api/Areas/";

        public async Task<bool> Delete(dynamic id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TbArea>> Get()
        {
            WebService<TbArea>.InitializeClient();
            return await WebService<TbArea>.GetAsync(RutaApi);
        }

        public Task<TbArea> GetById(string url)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Post(TbArea entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PostList(List<TbArea> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Put(TbArea entity)
        {
            throw new NotImplementedException();
        }
    }
}
