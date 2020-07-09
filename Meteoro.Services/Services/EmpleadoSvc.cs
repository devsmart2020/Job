using Meteoro.Entities.Entities;
using Meteoro.Entities.Helpers;
using Meteoro.Services.Data;
using Meteoro.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Services
{
    public class EmpleadoSvc : IEmpleadoSvc
    {      
        private readonly string RutaApi = "api/Empleados/";
        
        public Task<bool> Delete(dynamic id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<EmpleadosListado>> Get()
        {
            WebService<EmpleadosListado>.InitializeClient();
            return await WebService<EmpleadosListado>.GetAsync(RutaApi);
        }

        public Task<Tblempleado> GetById(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<Tblempleado> Login(Tblempleado entity) 
        {
            WebService<Tblempleado>.InitializeClient();
            return await WebService<Tblempleado>.LoginAsync(entity, $"{RutaApi}Login");

        }

        public async Task<bool> Post(Tblempleado entity)
        {
            WebService<Tblempleado>.InitializeClient();
            return await WebService<Tblempleado>.PostAsync(entity, RutaApi);
        }

        public Task<bool> PostList(List<Tblempleado> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Put(Tblempleado entity)
        {
            throw new NotImplementedException();
        }
    }
}
