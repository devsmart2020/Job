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
    public class CortesController : ControllerBase
    {
        private readonly ICorteRepository _repository;

        public CortesController(ICorteRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<bool>> Post(TbCorte entity)
        {
            if (entity != null)
            {
                var query = await _repository.Post(entity);
                if (query > 0)
                {
                    return Ok(true);
                }
                else
                {
                    return BadRequest(false);
                }
            }
            else
            {
                return NoContent();
            }
        }
    }
}
