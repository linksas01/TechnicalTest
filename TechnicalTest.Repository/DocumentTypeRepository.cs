using Microsoft.EntityFrameworkCore;
using TechnicalTest.Models;
using TechnicalTest.Repository.Interfaces;

namespace TechnicalTest.Repository
{
    public class DocumentTypeRepository : IDocumentTypeRepository
    {
        private readonly TechnicalTestContext _dbContext;

        public DocumentTypeRepository(TechnicalTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(DocumentType documentType)
        {
            _dbContext.DocumentTypes.Add(documentType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<DocumentType>> Get()
        {
            return await _dbContext.DocumentTypes.ToListAsync();
        }

        public async Task<DocumentType?> Get(byte id)
        {
            return await _dbContext.DocumentTypes.FindAsync(id);
        }

        public async Task Remove(DocumentType documentType)
        {
            _dbContext.DocumentTypes.Remove(documentType);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(DocumentType documentType)
        {
            _dbContext.Entry(documentType).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}