using Meteoro.Corte.API.Core.Interfaces;
using Meteoro.Corte.API.Infrastructure.Data;
using Meteoro.Corte.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Corte.API.Infrastructure.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly db_MeteoroCorteContext _context;

        public EmpresaRepository(db_MeteoroCorteContext context)
        {
            _context = context;
        }
        public async Task<int> Delete(dynamic id)
        {
            TbEmpresa TbEmpresa = await _context.TbEmpresa.FindAsync(id);
            if (TbEmpresa != null)
            {
                _context.Remove(TbEmpresa);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<TbEmpresa>> Get()
        {
            return await _context.TbEmpresa.ToListAsync();
        }

        public async Task<TbEmpresa> GetById(dynamic id)
        {
            return await _context.TbEmpresa.FindAsync(id);
        }

        public async Task<int> Post(TbEmpresa entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Put(TbEmpresa entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
