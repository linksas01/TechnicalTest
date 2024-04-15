using TechnicalTest.Models;

namespace TechnicalTest.Repository.Interfaces
{
    public interface IDocumentTypeRepository
    {
        Task Add(DocumentType documentType);        
        Task<IEnumerable<DocumentType>> Get();
        Task<DocumentType?> Get(byte id);
        Task Remove(DocumentType documentType);
        Task Update(DocumentType documentType);
    }
}