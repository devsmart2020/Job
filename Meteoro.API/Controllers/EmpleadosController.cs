using Meteoro.API.Core.Interfaces;
using Meteoro.Entities.Entities;
using Meteoro.Entities.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meteoro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoRepository _repository;

        public EmpleadosController(IEmpleadoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post(Tblempleado entity)
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
        public async Task<ActionResult<IEnumerable<EmpleadosListado>>> Get()
        {
            IEnumerable<EmpleadosListado> Tblempleados = await _repository.Get();
            if (Tblempleados.Any())
            {
                return Ok(Tblempleados);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("Actualizar")]
        public async Task<ActionResult<bool>> Put(Tblempleado entity)
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

        [HttpPost("GetById")]
        public async Task<ActionResult<Tblempleado>> GetById(Tblempleado entity)
        {
            if (!string.IsNullOrEmpty(entity.Codigo) || !string.IsNullOrEmpty(entity.DocId))
            {
                Tblempleado query = await _repository.GetById(entity);
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

        [HttpPost("Login")]
        public async Task<ActionResult<Tblempleado>> Login(Tblempleado entity)
        {
            if (entity != null)
            {
                Tblempleado tblempleado = await _repository.Login(entity);
                if (tblempleado != null)
                {

                    return Ok(tblempleado);
                }
                else
                {
                    return NotFound(null);
                }
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
