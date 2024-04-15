using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalTest.Business.Interfaces;
using TechnicalTest.Models;

namespace TechnicalTest.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaBusiness _areaBusiness;

        public AreaController(IAreaBusiness areaBusiness)
        {
            _areaBusiness = areaBusiness;
        }

        // GET: api/Area
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Area>>> Get()
        {
            return Ok(await _areaBusiness.Get());
        }

        // GET: api/Area/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Area>> Get(byte id)
        {
            var area = await _areaBusiness.Get(id);

            if (area == null)
            {
                return NotFound();
            }

            return Ok(area);
        }

        // DELETE: api/Area/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(byte id)
        {
            var area = await _areaBusiness.Get(id);
            if (area == null)
            {
                return NotFound();
            }

            await _areaBusiness.Remove(area);

            return NoContent();
        }

        // POST: api/Area
        [HttpPost]
        public async Task<ActionResult<Area>> Post(Area area)
        {
            try
            {
                await _areaBusiness.Add(area);
            }
            catch (DbUpdateException)
            {
                if (_areaBusiness.Get(area.Id) != null)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Get", new { id = area.Id }, area);
        }

        // PUT: api/Area/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(byte id, Area area)
        {
            if (id != area.Id)
            {
                return BadRequest();
            }

            try
            {
                await _areaBusiness.Update(area);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_areaBusiness.Get(area.Id) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
    }
}