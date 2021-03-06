﻿using Meteoro.API.Core.Interfaces;
using Meteoro.API.Infrastructure.Data;
using Meteoro.Entities.Entities;
using Meteoro.Entities.Helpers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<IEnumerable<EmpleadosListado>> Get()
        {
            IEnumerable<EmpleadosListado> tblempleado = await _context.Tblempleado
            .Select(x => new EmpleadosListado
            {
                Codigo = x.Codigo,
                Documento = x.DocId,
                Nombre = x.Nombre,
                Periodo = x.Periodo,
                Area = x.AreaNavigation.Nombre,
                Empresa = x.Empresa
            })
            .ToListAsync();            
            return tblempleado;

        }

        public async Task<Tblempleado> GetById(Tblempleado entity)
        {
            return await _context.Tblempleado
                .Where(x => x.Codigo.Equals(entity.Codigo) || x.DocId.Equals(entity.DocId))
                .FirstOrDefaultAsync();           
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
