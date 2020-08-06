using Meteoro.Entities.Entities;
using Meteoro.Entities.Helpers;
using Meteoro.Services.Data;
using Meteoro.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Meteoro.Services.Services
{
    public class AseguradorEmpleadoSvc : IAseguradorEmpleadoSvc
    {
        private readonly string RutaApi = "api/AseguradorEmpleado/";


        public async Task<bool> AsignarCosechadores(int revisiones)
        {
            WebService<Tblaseguradorempleado>.InitializeClient();            
            return await WebService<Tblaseguradorempleado>.GetAsyncBool($"{RutaApi}AsignarCosechadores/{revisiones}");           
        }

        public Task<bool> Delete(dynamic id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Tblaseguradorempleado>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Tblaseguradorempleado> GetById(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AseguradorEmpleadoListado>> ListarCosechadoresAsignados(IEnumerable<AseguradorEmpleadoListado> entity)
        {
            WebService<AseguradorEmpleadoListado>.InitializeClient();
            return await WebService<AseguradorEmpleadoListado>.GetPostAsync($"{RutaApi}CosechadoresAsignados", entity);
        }

        public Task<bool> Post(Tblaseguradorempleado entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PostList(List<Tblaseguradorempleado> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Put(Tblaseguradorempleado entity)
        {
            throw new NotImplementedException();
        }
    }
}
