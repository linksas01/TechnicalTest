using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalTest.Api.Models;
using TechnicalTest.Business.Interfaces;
using TechnicalTest.Models;
using TechnicalTest.Utilities.Exceptions;

namespace TechnicalTest.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ExtraHourController : ControllerBase
    {
        private readonly IExtraHourBusiness _extraHourBusiness;

        public ExtraHourController(IExtraHourBusiness extraHourBusiness)
        {
            _extraHourBusiness = extraHourBusiness;
        }

        // GET: api/ExtraHour
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExtraHour>>> Get()
        {
            return Ok(await _extraHourBusiness.Get());
        }

        // GET: api/ExtraHour/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ExtraHour>> Get(Guid id)
        {
            var extraHour = await _extraHourBusiness.Get(id);

            if (extraHour == null)
            {
                return NotFound();
            }

            return Ok(extraHour);
        }

        // DELETE: api/ExtraHour/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var extraHour = await _extraHourBusiness.Get(id);
            if (extraHour == null)
            {
                return NotFound();
            }

            await _extraHourBusiness.Remove(extraHour);

            return NoContent();
        }

        // POST: api/ExtraHour
        [HttpPost]
        public async Task<ActionResult<ExtraHour>> Post(ExtraHourModel extraHour)
        {
            try
            {
                await _extraHourBusiness.Add(new ExtraHour
                {
                    Id = extraHour.Id,
                    EmployeeId = extraHour.EmployeeId,
                    Date = extraHour.Date,
                    Hours = extraHour.Hours,
                    Description = extraHour.Description,
                    LeaderApproval = extraHour.LeaderApproval,
                    HumanResourcesApproval = extraHour.HumanResourcesApproval,
                    ManagerApproval = extraHour.ManagerApproval
                });
            }
            catch (BusinessException exception)
            {
                return Ok(new { message = exception.Message });
            }
            catch (DbUpdateException)
            {
                if (_extraHourBusiness.Get(extraHour.Id) != null)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Get", new { id = extraHour.Id }, extraHour);
        }

        // PUT: api/ExtraHour/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, ExtraHourModel extraHour)
        {
            if (id != extraHour.Id)
            {
                return BadRequest();
            }

            try
            {
                await _extraHourBusiness.Update(new ExtraHour
                {
                    Id = extraHour.Id,
                    EmployeeId = extraHour.EmployeeId,
                    Date = extraHour.Date,
                    Hours = extraHour.Hours,
                    Description = extraHour.Description,
                    LeaderApproval = extraHour.LeaderApproval,
                    HumanResourcesApproval = extraHour.HumanResourcesApproval,
                    ManagerApproval = extraHour.ManagerApproval
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_extraHourBusiness.Get(extraHour.Id) == null)
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