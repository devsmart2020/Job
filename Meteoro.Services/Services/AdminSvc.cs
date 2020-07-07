using Meteoro.Entities.Entities;
using Meteoro.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Services
{
    public class AdminSvc : IAdminSvc
    {
        private readonly IWebService<Tbladmin> _webService;
        private readonly string RutaApi = "api/Admins/";

        public AdminSvc(IWebService<Tbladmin> webService)
        {
            _webService = webService;
        }

        public async Task<bool> Delete(dynamic id)
        {
            return await _webService.DeleteAsync($"{RutaApi}{id}");
        }

        public async Task<IEnumerable<Tbladmin>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<Tbladmin> GetById(string url)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Post(Tbladmin entity)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> PostList(List<Tbladmin> entities)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Put(Tbladmin entity)
        {
            throw new NotImplementedException();
        }
    }
}
