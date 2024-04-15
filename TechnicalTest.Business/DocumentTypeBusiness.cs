using TechnicalTest.Business.Interfaces;
using TechnicalTest.Models;
using TechnicalTest.Repository.Interfaces;

namespace TechnicalTest.Business
{
    public class DocumentTypeBusiness : IDocumentTypeBusiness
    {
        private IDocumentTypeRepository _documentTypeRepository;

        public DocumentTypeBusiness(IDocumentTypeRepository documentTypeRepository) 
        {
            _documentTypeRepository = documentTypeRepository;
        }
        public async Task Add(DocumentType documentType)
        {
            await _documentTypeRepository.Add(documentType);
        }

        public async Task<IEnumerable<DocumentType>> Get()
        {
            return await _documentTypeRepository.Get();
        }

        public async Task<DocumentType?> Get(byte id)
        {
            return await _documentTypeRepository.Get(id);
        }

        public async Task Remove(DocumentType documentType)
        {            
            await _documentTypeRepository.Remove(documentType);
        }

        public async Task Update(DocumentType documentType)
        {            
            await _documentTypeRepository.Update(documentType);
        }
    }
}
