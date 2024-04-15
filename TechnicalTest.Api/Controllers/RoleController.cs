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
    public class RoleController : ControllerBase
    {
        private readonly IRoleBusiness _roleBusiness;

        public RoleController(IRoleBusiness roleBusiness)
        {
            _roleBusiness = roleBusiness;
        }

        // GET: api/Role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> Get()
        {
            return Ok(await _roleBusiness.Get());
        }

        // GET: api/Role/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> Get(byte id)
        {
            var role = await _roleBusiness.Get(id);

            if (role == null)
            {
                return NotFound();
            }

            return Ok(role);
        }

        // DELETE: api/Role/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(byte id)
        {
            var role = await _roleBusiness.Get(id);
            if (role == null)
            {
                return NotFound();
            }

            await _roleBusiness.Remove(role);

            return NoContent();
        }        

        // POST: api/Role
        [HttpPost]
        public async Task<ActionResult<Role>> Post(Role role)
        {
            try
            {
                await _roleBusiness.Add(role);
            }
            catch (DbUpdateException)
            {
                if (_roleBusiness.Get(role.Id) != null)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Get", new { id = role.Id }, role);
        }

        // PUT: api/Role/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(byte id, Role role)
        {
            if (id != role.Id)
            {
                return BadRequest();
            }

            try
            {
                await _roleBusiness.Update(role);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_roleBusiness.Get(role.Id) == null)
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