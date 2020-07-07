using Meteoro.API.Core.Interfaces;
using Meteoro.API.Infrastructure.Data;
using Meteoro.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.API.Infrastructure.Repositories
{
    public class SemanaRepository : ISemanaRepository
    {

        private readonly db_meteorocosechaContext _context;

        public SemanaRepository(db_meteorocosechaContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(dynamic id)
        {
            Tblsemana tblsemana = await _context.Tblsemana.FindAsync(id);
            if (tblsemana != null)
            {
                _context.Remove(tblsemana);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<Tblsemana>> Get()
        {
            return await _context.Tblsemana.ToListAsync();
        }

        public async Task<Tblsemana> GetById(dynamic id)
        {
            return await _context.Tblsemana.FindAsync(id);
        }

        public async Task<int> Post(Tblsemana entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Put(Tblsemana entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
