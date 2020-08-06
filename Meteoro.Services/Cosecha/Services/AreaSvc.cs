using Meteoro.Entities.Entities;
using Meteoro.Services.Data;
using Meteoro.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Services
{
    public class AreaSvc : IAreaSvc
    {
        private readonly string RutaApi = "api/Areas/";

        public Task<bool> Delete(dynamic id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Tblarea>> Get()
        {
            WebService<Tblarea>.InitializeClient();
            return await WebService<Tblarea>.GetAsync(RutaApi);
        }

        public Task<Tblarea> GetById(string url)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Post(Tblarea entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PostList(List<Tblarea> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Put(Tblarea entity)
        {
            throw new NotImplementedException();
        }
    }
}
