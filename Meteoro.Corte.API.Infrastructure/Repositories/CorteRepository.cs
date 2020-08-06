using Meteoro.Corte.API.Core.Interfaces;
using Meteoro.Corte.API.Infrastructure.Data;
using Meteoro.Corte.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Corte.API.Infrastructure.Repositories
{
    public class CorteRepository : ICorteRepository
    {
        private readonly db_MeteoroCorteContext _context;

        public CorteRepository(db_MeteoroCorteContext context)
        {
            _context = context;
        }
        public async Task<int> Delete(dynamic id)
        {
            TbCorte tblcosecha = await _context.TbCorte.FindAsync(id);
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

        public async Task<IEnumerable<object>> Get()
        {
            return await _context.TbCorte.ToListAsync();

        }

        public async Task<TbCorte> GetById(TbCorte entity)
        {
            return await _context.TbCorte.FindAsync(entity.Id);
        }

        public async Task<int> Post(TbCorte entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Put(TbCorte entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
