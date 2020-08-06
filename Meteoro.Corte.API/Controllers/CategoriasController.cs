using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Meteoro.Corte.API.Core.Interfaces;
using Meteoro.Corte.Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Meteoro.Corte.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaRepository _repository;

        public CategoriasController(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post(TbCategoria entity)
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
        public async Task<ActionResult<IEnumerable<TbCategoria>>> Get()
        {
            IEnumerable<TbCategoria> TbCategorias = await _repository.Get();
            if (TbCategorias.Any())
            {
                return Ok(TbCategorias);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<bool>> Put(TbCategoria entity)
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
        public async Task<ActionResult<TbCategoria>> GetById(dynamic id)
        {
            if (id != null)
            {
                TbCategoria query = await _repository.GetById(id);
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
    }
}
