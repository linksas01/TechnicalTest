using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TechnicalTest.Api.Models;
using TechnicalTest.Business.Interfaces;
using TechnicalTest.Models;
using TechnicalTest.Utilities.Exceptions;

namespace TechnicalTest.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeBusiness _employeeBusiness;

        public EmployeeController(IEmployeeBusiness employeeBusiness)
        {
            _employeeBusiness = employeeBusiness;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            return Ok(await _employeeBusiness.Get());
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(Guid id)
        {
            var employee = await _employeeBusiness.Get(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = await _employeeBusiness.Get(id);
            if (employee == null)
            {
                return NotFound();
            }

            await _employeeBusiness.Remove(employee);

            return NoContent();
        }

        // POST: api/Employee
        [HttpPost]
        public async Task<ActionResult<Employee>> Post(EmployeeModel employee)
        {
            try
            {
                await _employeeBusiness.Add(new Employee
                {
                    Id = employee.Id,
                    DocumentTypeId = employee.DocumentTypeId,
                    DocumentNumber = employee.DocumentNumber,
                    Name = employee.Name,
                    Surname = employee.Surname,
                    Email = employee.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(employee.Password, BCrypt.Net.BCrypt.GenerateSalt()),
                    LeaderId = employee.LeaderId,
                    AreaId = employee.AreaId,
                    RolId = employee.RolId
                });
            }
            catch (BusinessException exception)
            {
                return Ok(new { message = exception.Message });
            }
            catch (DbUpdateException)
            {
                if (_employeeBusiness.Get(employee.Id) != null)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Get", new { id = employee.Id }, employee);
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, EmployeeModel employee)
        {
            if (!id.Equals(employee.Id))
            {
                return BadRequest();
            }

            try
            {
                await _employeeBusiness.Update(new Employee
                {
                    Id = employee.Id,
                    DocumentTypeId = employee.DocumentTypeId,
                    DocumentNumber = employee.DocumentNumber,
                    Name = employee.Name,
                    Surname = employee.Surname,
                    Email = employee.Email,
                    Password = BCrypt.Net.BCrypt.HashPassword(employee.Password, BCrypt.Net.BCrypt.GenerateSalt()),
                    LeaderId = employee.LeaderId,
                    AreaId = employee.AreaId,
                    RolId = employee.RolId
                });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_employeeBusiness.Get(employee.Id) == null)
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