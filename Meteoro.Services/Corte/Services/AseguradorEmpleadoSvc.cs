using Meteoro.Corte.Entities.Entities;
using Meteoro.Corte.Entities.Helpers;
using Meteoro.Services.Corte.Interfaces;
using Meteoro.Services.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Corte.Services
{

    public class AseguradorEmpleadoSvc : IAseguradorEmpleadoSvc
    {
        private readonly string RutaApi = "api/AseguradorEmpleados/";

        public async Task<bool> ActualizarRevision(TbAseguradorEmpleado entity)
        {
            WebService<TbAseguradorEmpleado>.InitializeClient();
            return await WebService<TbAseguradorEmpleado>.PutAsync(entity, RutaApi);
        }

        public async Task<bool> AsignarCosechadores(int revisiones)
        {
            WebService<TbAseguradorEmpleado>.InitializeClient();            
            return await WebService<TbAseguradorEmpleado>.GetAsyncBool($"{RutaApi}AsignarCosechadores/{revisiones}");           
        }

        public Task<bool> Delete(dynamic id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TbAseguradorEmpleado>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<TbAseguradorEmpleado> GetById(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AseguradorEmpleadoListado>> ListarCosechadoresAsignados(IEnumerable<AseguradorEmpleadoListado> entity)
        {
            WebService<AseguradorEmpleadoListado>.InitializeClient();
            return await WebService<AseguradorEmpleadoListado>.GetPostAsync($"{RutaApi}CosechadoresAsignados", entity);
        }

        public async Task<TbAseguradorEmpleado> ObtenerIdRevision(TbAseguradorEmpleado entity)
        {
            WebService<TbAseguradorEmpleado>.InitializeClient();
            return await WebService<TbAseguradorEmpleado>.PostAsyncEntity(entity, "api/AseguradorEmpleados/obtenerid");
        }

        public Task<bool> Post(TbAseguradorEmpleado entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PostList(List<TbAseguradorEmpleado> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Put(TbAseguradorEmpleado entity)
        {
            throw new NotImplementedException();
        }
    }
}
