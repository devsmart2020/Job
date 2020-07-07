using Meteoro.API.Core.Interfaces;
using Meteoro.API.Infrastructure.Data;
using Meteoro.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.API.Infrastructure.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly db_meteorocosechaContext _context;

        public AdminRepository(db_meteorocosechaContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(dynamic id)
        {
            Tbladmin tbladmin = await _context.Tbladmin.FindAsync(id);
            if (tbladmin != null)
            {
                _context.Remove(tbladmin);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<Tbladmin>> Get()
        {
            return await _context.Tbladmin.ToListAsync();
        }

        public async Task<Tbladmin> GetById(dynamic id)
        {
            return await _context.Tbladmin.FindAsync(id);
        }

        public async Task<int> Post(Tbladmin entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Put(Tbladmin entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync(); 
        }
    }
}
