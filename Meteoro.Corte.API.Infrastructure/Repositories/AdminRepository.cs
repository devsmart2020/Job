using Meteoro.Corte.API.Core.Interfaces;
using Meteoro.Corte.API.Infrastructure.Data;
using Meteoro.Corte.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Corte.API.Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly db_MeteoroCorteContext _context;

        public AdminRepository(db_MeteoroCorteContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(dynamic id)
        {
            TbAdmin TbAdmin = await _context.TbAdmin.FindAsync(id);
            if (TbAdmin != null)
            {
                _context.Remove(TbAdmin);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<TbAdmin>> Get()
        {
            return await _context.TbAdmin.ToListAsync();
        }

        public async Task<TbAdmin> GetById(dynamic id)
        {
            return await _context.TbAdmin.FindAsync(id);
        }

        public async Task<int> Post(TbAdmin entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Put(TbAdmin entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
