using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meteoro.API.Core.Interfaces;
using Meteoro.Entities.Entities;
using Meteoro.Entities.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Meteoro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AseguradorEmpleadoController : ControllerBase
    {
        private readonly IAseguradorEmpleadoRepository _repository;

        public AseguradorEmpleadoController(IAseguradorEmpleadoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post(Tblaseguradorempleado entity)
        {
            if (entity != null)
            {
                int query = await _repository.Post(entity);
                if (query > 0)
                {
                    return Created("", true);
                }
                else
                {
                    return Conflict(null);
                }
            }
            else
            {
                return BadRequest(null);
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tblaseguradorempleado>>> Get()
        {
            IEnumerable<Tblaseguradorempleado> Tblaseguradorempleados = await _repository.Get();
            if (Tblaseguradorempleados.Any())
            {
                return Ok(Tblaseguradorempleados);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(Tblaseguradorempleado entity)
        {
            if (entity != null)
            {
                int query = await _repository.Put(entity);
                if (query > 0)
                {
                    return Ok(true);
                }
                else
                {
                    return Conflict(false);
                }
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Tblaseguradorempleado>> GetById(dynamic id)
        {
            if (id != null)
            {
                Tblaseguradorempleado query = await _repository.GetById(id);
                if (query != null)
                {
                    return Ok(query);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(dynamic id)
        {
            if (id != null)
            {
                int query = await _repository.Delete(id);
                if (query > 0)
                {
                    return Ok(true);
                }
                else
                {
                    return Conflict(false);
                }
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("AsignarCosechadores/{revisiones}")]
        public async Task<ActionResult> AseguradorEmpleados(int revisiones)
        {
            if (!revisiones.Equals(0))
            {              
                if (await _repository.AsignarCosechadores(revisiones))
                {                                     
                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("CosechadoresAsignados")]
        public async Task<ActionResult<IEnumerable<AseguradorEmpleadoListado>>> ListarCosechadoresAsignados()
        {
            return Ok(await _repository.ListarCosechadoresAsignados());
        }
    }
}
