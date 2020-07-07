using Meteoro.API.Core.Interfaces;
using Meteoro.API.Infrastructure.Data;
using Meteoro.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Meteoro.API.Infrastructure.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly db_meteorocosechaContext _context;

        public EmpleadoRepository(db_meteorocosechaContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(dynamic id)
        {
            Tblempleado tblempleado = await _context.Tblempleado.FindAsync(id);
            if (tblempleado != null)
            {
                _context.Remove(tblempleado);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<Tblempleado>> Get()
        {
            return await _context.Tblempleado.ToListAsync();
        }

        public async Task<Tblempleado> GetById(dynamic id)
        {
            return await _context.Tblempleado.FindAsync(id);
        }

        public async Task<Tblempleado> Login(Tblempleado entity)
        {
            return await _context.Tblempleado
                .Where(x => entity.Codigo.Equals(x.Codigo) && entity.Pass.Equals(x.Pass) && x.Estado == true)
                .FirstOrDefaultAsync();                
        }

        public async Task<int> Post(Tblempleado entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Put(Tblempleado entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
