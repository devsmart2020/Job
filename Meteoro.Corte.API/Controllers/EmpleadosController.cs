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
    public class EmpleadosController : ControllerBase
    {
        private readonly IEmpleadoRepository _repository;

        public EmpleadosController(IEmpleadoRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post(TbEmpleado entity)
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
            IEnumerable<EmpleadosListado> TbEmpleados = await _repository.Get();
            if (TbEmpleados.Any())
            {
                return Ok(TbEmpleados);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("Actualizar")]
        public async Task<ActionResult<bool>> Put(TbEmpleado entity)
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
        public async Task<ActionResult<TbEmpleado>> GetById(TbEmpleado entity)
        {
            if (!string.IsNullOrEmpty(entity.Codigo) || !string.IsNullOrEmpty(entity.DocId))
            {
                TbEmpleado query = await _repository.GetById(entity);
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
        public async Task<ActionResult<TbEmpleado>> Login(TbEmpleado entity)
        {
            if (entity != null)
            {
                TbEmpleado TbEmpleado = await _repository.Login(entity);
                if (TbEmpleado != null)
                {

                    return Ok(TbEmpleado);
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
