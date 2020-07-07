using Meteoro.API.Core.Interfaces;
using Meteoro.API.Infrastructure.Data;
using Meteoro.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.API.Infrastructure.Repositories
{
    public class AseguradorEmpleadoRepository : IAseguradorEmpleadoRepository
    {
        private readonly db_meteorocosechaContext _context;

        public AseguradorEmpleadoRepository(db_meteorocosechaContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(dynamic id)
        {
            Tblaseguradorempleado tblaseguradorempleado = await _context.Tblaseguradorempleado.FindAsync(id);
            if (tblaseguradorempleado != null)
            {
                _context.Remove(tblaseguradorempleado);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<Tblaseguradorempleado>> Get()
        {
            return await _context.Tblaseguradorempleado.ToListAsync();
        }

        public async Task<Tblaseguradorempleado> GetById(dynamic id)
        {
            return await _context.Tblaseguradorempleado.FindAsync(id);
        }

        public async Task<int> Post(Tblaseguradorempleado entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Put(Tblaseguradorempleado entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

    }
}
