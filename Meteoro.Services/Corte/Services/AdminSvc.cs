using Meteoro.Corte.Entities.Entities;
using Meteoro.Services.Corte.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Corte.Services
{
    public class AdminSvc : IAdminSvc
    {
        private readonly IWebService<TbAdmin> _webService;
        private readonly string RutaApi = "api/Admins/";

        public AdminSvc(IWebService<TbAdmin> webService)
        {
            _webService = webService;
        }

        public async Task<bool> Delete(dynamic id)
        {
            return await _webService.DeleteAsync($"{RutaApi}{id}");
        }

        public async Task<IEnumerable<TbAdmin>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<TbAdmin> GetById(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Post(TbAdmin entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PostList(List<TbAdmin> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Put(TbAdmin entity)
        {
            throw new NotImplementedException();
        }
    }
}
