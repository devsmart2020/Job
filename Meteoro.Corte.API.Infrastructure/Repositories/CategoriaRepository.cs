using Meteoro.Corte.API.Core.Interfaces;
using Meteoro.Corte.API.Infrastructure.Data;
using Meteoro.Corte.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Meteoro.Corte.API.Infrastructure.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly db_MeteoroCorteContext _context;

        public CategoriaRepository(db_MeteoroCorteContext context)
        {
            _context = context;
        }

        public async Task<int> Delete(dynamic id)
        {
            TbCategoria TbCategoria = await _context.TbCategoria.FindAsync(id);
            if (TbCategoria != null)
            {
                _context.Remove(TbCategoria);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<TbCategoria>> Get()
        {
            return await _context.TbCategoria.ToListAsync();
        }     

        public async Task<TbCategoria> GetById(TbCategoria entity)
        {
            return await _context.TbCategoria.FindAsync(entity.Id);
        }

        public async Task<int> Post(TbCategoria entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Put(TbCategoria entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
