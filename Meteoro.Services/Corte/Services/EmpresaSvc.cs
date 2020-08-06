using Meteoro.Corte.Entities.Entities;
using Meteoro.Services.Corte.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Services.Corte.Services
{

    public class EmpresaSvc : IEmpresaSvc
    {
        public Task<bool> Delete(dynamic id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TbEmpresa>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<TbEmpresa> GetById(string url)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Post(TbEmpresa entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> PostList(List<TbEmpresa> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Put(TbEmpresa entity)
        {
            throw new NotImplementedException();
        }
    }
}
