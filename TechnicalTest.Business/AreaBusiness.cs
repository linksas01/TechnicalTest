using TechnicalTest.Business.Interfaces;
using TechnicalTest.Models;
using TechnicalTest.Repository.Interfaces;

namespace TechnicalTest.Business
{
    public class AreaBusiness : IAreaBusiness
    {
        private IAreaRepository _areaRepository;

        public AreaBusiness(IAreaRepository areaRepository)
        {
            _areaRepository = areaRepository;
        }
        public async Task Add(Area area)
        {
            await _areaRepository.Add(area);
        }       

        public async Task<IEnumerable<Area>> Get()
        {
            return await _areaRepository.Get();
        }

        public async Task<Area?> Get(byte id)
        {
            return await _areaRepository.Get(id);
        }

        public async Task Remove(Area area)
        {
            await _areaRepository.Remove(area);
        }

        public async Task Update(Area area)
        {
            await _areaRepository.Update(area);
        }
    }
}