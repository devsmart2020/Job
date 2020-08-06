using Meteoro.API.Core.Interfaces;
using Meteoro.API.Infrastructure.Data;
using Meteoro.Entities.Entities;
using Meteoro.Entities.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
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

        public async Task<bool> AsignarCosechadores(int revisiones)
        {
            IList<Tblempleado> cosechadores = await _context.Tblempleado
                .Where(x => x.Estado.Equals(true) && x.Area.Equals(5))
                .OrderBy(x => Guid.NewGuid())
                .ToListAsync();

            IList<Tblempleado> aseguradores = await _context.Tblempleado
                .Where(x => x.Estado.Equals(true) && x.Area.Equals(4))
                .ToListAsync();

            int nAseguradores = aseguradores.Count();
            int indiceAseguradores = 0;
            List<Tblaseguradorempleado> tblaseguradorempleados = new List<Tblaseguradorempleado>();
            foreach (var item in cosechadores)
            {
                if (indiceAseguradores.Equals(nAseguradores))
                {
                    indiceAseguradores = 0;
                }
                tblaseguradorempleados.Add(new Tblaseguradorempleado
                {
                    Asegurador = aseguradores[indiceAseguradores].Codigo,
                    Empleado = item.Codigo,
                    Fecha = DateTime.Today,
                    Revisiones = revisiones,
                    Sync = false
                });
                indiceAseguradores++;
            }
            await _context.AddRangeAsync(tblaseguradorempleados);
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

        public async  Task<IEnumerable<AseguradorEmpleadoListado>> ListarCosechadoresAsignados()
        {
            IList<Tblaseguradorempleado> tblaseguradorempleados = await _context.Tblaseguradorempleado
                .Where(x => x.Sync.Equals(false) && x.Fecha.Date.Equals(DateTime.Today.Date))
                .ToListAsync();

            IList<Tblempleado> tblempleados = await _context.Tblempleado
                .Where(x => x.Estado.Equals(true) && x.Area.Equals(5) )
                .ToListAsync();
            List<AseguradorEmpleadoListado> aseguradorEmpleados = new List<AseguradorEmpleadoListado>();

            var query = (from ae in tblaseguradorempleados
                         join em in tblempleados
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
