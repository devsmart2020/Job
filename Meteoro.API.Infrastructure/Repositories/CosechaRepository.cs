using Meteoro.API.Core.Interfaces;
using Meteoro.API.Infrastructure.Data;
using Meteoro.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.API.Infrastructure.Repositories
{
    public class CosechaRepository : ICosechaRepository
    {
        private readonly db_meteorocosechaContext _context;

        public CosechaRepository(db_meteorocosechaContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(dynamic id)
        {
            Tblcosecha tblcosecha = await _context.Tblcosecha.FindAsync(id);
            if (tblcosecha != null)
            {
                _context.Remove(tblcosecha);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<Tblcosecha>> Get()
        {
            return await _context.Tblcosecha.ToListAsync();
        }

        public async Task<Tblcosecha> GetById(dynamic id)
        {
            return await _context.Tblcosecha.FindAsync(id);
        }

        public async Task<int> Post(Tblcosecha entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Put(Tblcosecha entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
