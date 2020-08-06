using Meteoro.Corte.API.Core.Interfaces;
using Meteoro.Corte.API.Infrastructure.Data;
using Meteoro.Corte.Entities.Entities;
using Meteoro.Corte.Entities.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meteoro.Corte.API.Infrastructure.Repositories
{
    public class EmpleadoRepository : IEmpleadoRepository
    {
        private readonly db_MeteoroCorteContext _context;

        public EmpleadoRepository(db_MeteoroCorteContext context)
        {
            _context = context;
        }
        public async Task<int> Delete(dynamic id)
        {
            TbEmpleado TbEmpleado = await _context.TbEmpleado.FindAsync(id);
            if (TbEmpleado != null)
            {
                _context.Remove(TbEmpleado);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<EmpleadosListado>> Get()
        {
            IEnumerable<EmpleadosListado> TbEmpleado = await _context.TbEmpleado
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
            return TbEmpleado;

        }

        public async Task<TbEmpleado> GetById(TbEmpleado entity)
        {
            return await _context.TbEmpleado
                .Where(x => x.Codigo.Equals(entity.Codigo) || x.DocId.Equals(entity.DocId))
                .FirstOrDefaultAsync();
        }

        public async Task<TbEmpleado> Login(TbEmpleado entity)
        {
            return await _context.TbEmpleado
                .Where(x => entity.Codigo.Equals(x.Codigo) && entity.Pass.Equals(x.Pass) && x.Estado == true)
                .FirstOrDefaultAsync();
        }

        public async Task<int> Post(TbEmpleado entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Put(TbEmpleado entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }
    }
}
