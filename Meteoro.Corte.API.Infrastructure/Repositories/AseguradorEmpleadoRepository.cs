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
    public class AseguradorEmpleadoRepository : IAseguradorEmpleadoRepository
    {
        private readonly db_MeteoroCorteContext _context;

        public AseguradorEmpleadoRepository(db_MeteoroCorteContext context)
        {
            _context = context;
        }

        public async Task<bool> AsignarCosechadores(int revisiones)
        {
            IList<TbEmpleado> cosechadores = await _context.TbEmpleado
                .Where(x => x.Estado.Equals(true) && x.Area.Equals(2))
                .OrderBy(x => Guid.NewGuid())
                .ToListAsync();

            IList<TbEmpleado> aseguradores = await _context.TbEmpleado
                .Where(x => x.Estado.Equals(true) && x.Area.Equals(3))
                .ToListAsync();

            int nAseguradores = aseguradores.Count();
            int indiceAseguradores = 0;
            List<TbAseguradorEmpleado> TbAseguradorempleados = new List<TbAseguradorEmpleado>();
            foreach (var item in cosechadores)
            {
                if (indiceAseguradores.Equals(nAseguradores))
                {
                    indiceAseguradores = 0;
                }
                TbAseguradorempleados.Add(new TbAseguradorEmpleado
                {
                    Asegurador = aseguradores[indiceAseguradores].Codigo,
                    Empleado = item.Codigo,
                    Fecha = DateTime.Today,
                    Revisiones = revisiones,
                    Sync = false
                });
                indiceAseguradores++;
            }
            await _context.AddRangeAsync(TbAseguradorempleados);
            var query = await _context.SaveChangesAsync();
            if (query > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<int> Delete(dynamic id)
        {
            TbAseguradorEmpleado TbAseguradorempleado = await _context.TbAseguradorEmpleado.FindAsync(id);
            if (TbAseguradorempleado != null)
            {
                _context.Remove(TbAseguradorempleado);
                return await _context.SaveChangesAsync();
            }
            else
            {
                return 0;
            }
        }

        public async Task<IEnumerable<TbAseguradorEmpleado>> Get()
        {
            return await _context.TbAseguradorEmpleado.ToListAsync();
        }

        public async Task<TbAseguradorEmpleado> GetById(dynamic id)
        {
            return await _context.TbAseguradorEmpleado.FindAsync(id);
        }    

        public async Task<int> Post(TbAseguradorEmpleado entity)
        {
            await _context.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Put(TbAseguradorEmpleado entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AseguradorEmpleadoListado>> ListarCosechadoresAsignados()
        {
            IList<TbAseguradorEmpleado> TbAseguradorempleados = await _context.TbAseguradorEmpleado
                .Where(x => x.Sync.Equals(false) && x.Fecha.Date.Equals(DateTime.Today.Date))
                .ToListAsync();

            IList<TbEmpleado> TbEmpleados = await _context.TbEmpleado
                .Where(x => x.Estado.Equals(true) && x.Area.Equals(2))
                .ToListAsync();
            List<AseguradorEmpleadoListado> aseguradorEmpleados = new List<AseguradorEmpleadoListado>();

            var query = (from ae in TbAseguradorempleados
                         join em in TbEmpleados
                             on ae.Empleado equals em.Codigo
                         where ae.Revisiones > 0
                         select new
                         {
                             Codigo = ae.Asegurador,
                             CodigoEmpleado = em.Codigo,
                             Nombres = em.Nombre,
                             ae.Fecha,
                             Revision = ae.Revisiones,
                             ae.Sync,
                             em.Area
                         }).OrderBy(ae => ae.Nombres);

            foreach (var item in query)
            {
                AseguradorEmpleadoListado aseguradorEmpleadoListado = new AseguradorEmpleadoListado();
                aseguradorEmpleadoListado.Colaborador = $"{item.Nombres} - {item.CodigoEmpleado}";
                aseguradorEmpleadoListado.Revisiones = item.Revision;
                aseguradorEmpleadoListado.Fecha = item.Fecha;
                aseguradorEmpleadoListado.Asegurador = item.Codigo;
                aseguradorEmpleadoListado.Area = item.Area;
                aseguradorEmpleados.Add(aseguradorEmpleadoListado);
            }
            return aseguradorEmpleados;
        }
    }
}
