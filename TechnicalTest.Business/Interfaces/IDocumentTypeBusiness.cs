using TechnicalTest.Models;

namespace TechnicalTest.Business.Interfaces
{
    public interface IDocumentTypeBusiness
    {
        Task Add(DocumentType documentType);
        Task<IEnumerable<DocumentType>> Get();
        Task<DocumentType?> Get(byte id);
        Task Remove(DocumentType documentType);
        Task Update(DocumentType documentType);
    }
}
