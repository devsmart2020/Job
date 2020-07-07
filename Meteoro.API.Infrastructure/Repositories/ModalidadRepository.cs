using Meteoro.API.Core.Interfaces;
using Meteoro.API.Infrastructure.Data;
using Meteoro.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.API.Infrastructure.Repositories
{
    public class ModalidadRepository : IModalidadRepository
    {

        private readonly db_meteorocosechaContext _context;

        public ModalidadRepository(db_meteorocosechaContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(dynamic id)
        {
            Tblmodalidad tblmodalidad = await _context.Tblmodalidad.FindAsync(id);
            if (tblmodalidad != null)
            {
                _context.Remove(tblmodalidad);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<Tblmodalidad>> Get()
        {
            return await _context.Tblmodalidad.ToListAsync();
        }

        public async Task<Tblmodalidad> GetById(dynamic id)
        {
            return _context.Tblmodalidad.FindAsync(id);
        }

        public async Task<int> Post(Tblmodalidad entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Put(Tblmodalidad entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
