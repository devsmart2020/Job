using Meteoro.API.Core.Interfaces;
using Meteoro.API.Infrastructure.Data;
using Meteoro.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.API.Infrastructure.Repositories
{
    public class RegistroRepository : IRegistroRepository
    {
        private readonly db_meteorocosechaContext _context;

        public RegistroRepository(db_meteorocosechaContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(dynamic id)
        {
            Tblregistro tblregistro = await _context.Tblregistro.FindAsync(id);
            if (tblregistro != null)
            {
                _context.Remove(tblregistro);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<Tblregistro>> Get()
        {
            return await _context.Tblregistro.ToListAsync();
        }

        public async Task<Tblregistro> GetById(dynamic id)
        {
            return await _context.FindAsync(id);
        }

        public async Task<int> Post(Tblregistro entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Put(Tblregistro entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
