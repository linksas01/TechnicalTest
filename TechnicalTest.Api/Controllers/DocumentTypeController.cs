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
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeBusiness _documentTypeBusiness;

        public DocumentTypeController(IDocumentTypeBusiness documentTypeBusiness)
        {
            _documentTypeBusiness = documentTypeBusiness;
        }

        // GET: api/DocumentType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentType>>> Get()
        {
            return Ok(await _documentTypeBusiness.Get());
        }

        // GET: api/DocumentType/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentType>> Get(byte id)
        {
            var documentType = await _documentTypeBusiness.Get(id);

            if (documentType == null)
            {
                return NotFound();
            }

            return Ok(documentType);
        }

        // DELETE: api/DocumentType/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(byte id)
        {
            var documentType = await _documentTypeBusiness.Get(id);
            if (documentType == null)
            {
                return NotFound();
            }

            await _documentTypeBusiness.Remove(documentType);

            return NoContent();
        }

        // POST: api/DocumentType
        [HttpPost]
        public async Task<ActionResult<DocumentType>> Post(DocumentType documentType)
        {
            try
            {
                await _documentTypeBusiness.Add(documentType);
            }
            catch (DbUpdateException)
            {
                if (_documentTypeBusiness.Get(documentType.Id) != null)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("Get", new { id = documentType.Id }, documentType);
        }

        // PUT: api/DocumentType/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(byte id, DocumentType documentType)
        {
            if (id != documentType.Id)
            {
                return BadRequest();
            }

            try
            {
                await _documentTypeBusiness.Update(documentType);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_documentTypeBusiness.Get(documentType.Id) == null)
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