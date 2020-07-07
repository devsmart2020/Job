using Meteoro.API.Core.Interfaces;
using Meteoro.API.Infrastructure.Data;
using Meteoro.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.API.Infrastructure.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly db_meteorocosechaContext _context;

        public AreaRepository(db_meteorocosechaContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(dynamic id)
        {
            Tblarea tblarea = await _context.Tblarea.FindAsync(id);
            if (tblarea != null)
            {
                _context.Remove(tblarea);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<Tblarea>> Get()
        {
            return await _context.Tblarea.ToListAsync();
        }

        public async Task<Tblarea> GetById(dynamic id)
        {
            return await _context.Tblarea.FindAsync(id);
        }

        public async Task<int> Post(Tblarea entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Put(Tblarea entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
