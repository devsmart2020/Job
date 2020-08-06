using Meteoro.Corte.Entities.Entities;
using Meteoro.Corte.Entities.Helpers;
using Meteoro.Services.Corte.Interfaces;
using Meteoro.Services.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Corte.Services
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

        public async Task<TbEmpleado> GetById(TbEmpleado entity)
        {
            WebService<TbEmpleado>.InitializeClient();
            return await WebService<TbEmpleado>.GetByIdAsync(entity, $"{RutaApi}GetById");
        }

        public async Task<TbEmpleado> Login(TbEmpleado entity) 
        {
            WebService<TbEmpleado>.InitializeClient();
            return await WebService<TbEmpleado>.LoginAsync(entity, $"{RutaApi}Login");

        }

        public async Task<bool> Post(TbEmpleado entity)
        {
            WebService<TbEmpleado>.InitializeClient();
            return await WebService<TbEmpleado>.PostAsync(entity, RutaApi);
        }

        public Task<bool> PostList(List<TbEmpleado> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Put(TbEmpleado entity)
        {
            WebService<TbEmpleado>.InitializeClient();
            return await WebService<TbEmpleado>.PutAsync(entity, $"{RutaApi}Actualizar");
        }
    }
}
