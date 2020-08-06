using Meteoro.Corte.API.Core.Interfaces;
using Meteoro.Corte.API.Infrastructure.Data;
using Meteoro.Corte.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meteoro.Corte.API.Infrastructure.Repositories
{
    public class AreaRepository : IAreaRepository
    {
        private readonly db_MeteoroCorteContext _context;

        public AreaRepository(db_MeteoroCorteContext context)
        {
            _context = context;
        }


        public async Task<int> Delete(dynamic id)
        {
            TbArea TbArea = await _context.TbArea.FindAsync(id);
            if (TbArea != null)
            {
                _context.Remove(TbArea);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<TbArea>> Get()
        {
            return await _context.TbArea
                .OrderBy(x => x.Nombre)
                .ToListAsync();

        }

        public async Task<TbArea> GetById(dynamic id)
        {
            return await _context.TbArea.FindAsync(id);
        }

        public async Task<int> Post(TbArea entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Put(TbArea entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
