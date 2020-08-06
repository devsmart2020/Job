using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meteoro.Corte.API.Core.Interfaces;
using Meteoro.Corte.Entities.Entities;
using Meteoro.Corte.Entities.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Meteoro.Corte.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AseguradorEmpleadosController : ControllerBase
    {
        private readonly IAseguradorEmpleadoRepository _repository;

        public AseguradorEmpleadosController(IAseguradorEmpleadoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post(TbAseguradorEmpleado entity)
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
        public async Task<ActionResult<IEnumerable<TbAseguradorEmpleado>>> Get()
        {
            IEnumerable<TbAseguradorEmpleado> TbAseguradorEmpleados = await _repository.Get();
            if (TbAseguradorEmpleados.Any())
            {
                return Ok(TbAseguradorEmpleados);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(TbAseguradorEmpleado entity)
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
        public async Task<ActionResult<TbAseguradorEmpleado>> GetById(dynamic id)
        {
            if (id != null)
            {
                TbAseguradorEmpleado query = await _repository.GetById(id);
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
