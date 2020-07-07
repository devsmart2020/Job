using Meteoro.API.Core.Interfaces;
using Meteoro.API.Infrastructure.Data;
using Meteoro.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.API.Infrastructure.Repositories
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly db_meteorocosechaContext _context;

        public EmpresaRepository(db_meteorocosechaContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(dynamic id)
        {
            Tblempresa tblempresa = await _context.Tblempresa.FindAsync(id);
            if (tblempresa != null)
            {
                _context.Remove(tblempresa);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<Tblempresa>> Get()
        {
            return await _context.Tblempresa.ToListAsync();
        }

        public async Task<Tblempresa> GetById(dynamic id)
        {
            return await _context.Tblempresa.FindAsync(id);
        }

        public async Task<int> Post(Tblempresa entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Put(Tblempresa entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
