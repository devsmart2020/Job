using Meteoro.Corte.API.Core.Interfaces;
using Meteoro.Corte.API.Infrastructure.Data;
using Meteoro.Corte.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Corte.API.Infrastructure.Repositories
{
    public class SemanaRepository : ISemanaRepository
    {
        private readonly db_MeteoroCorteContext _context;

        public SemanaRepository(db_MeteoroCorteContext context)
        {
            _context = context;
        }
        public async Task<int> Delete(dynamic id)
        {
            TbSemana TbSemana = await _context.TbSemana.FindAsync(id);
            if (TbSemana != null)
            {
                _context.Remove(TbSemana);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<TbSemana>> Get()
        {
            return await _context.TbSemana.ToListAsync();
        }

        public async Task<TbSemana> GetById(dynamic id)
        {
            return await _context.TbSemana.FindAsync(id);
        }

        public async Task<int> Post(TbSemana entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Put(TbSemana entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
