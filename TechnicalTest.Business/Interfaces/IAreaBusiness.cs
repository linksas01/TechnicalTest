using TechnicalTest.Models;

namespace TechnicalTest.Business.Interfaces
{
    public interface IAreaBusiness
    {
        Task Add(Area area);
        Task<IEnumerable<Area>> Get();
        Task<Area?> Get(byte id);
        Task Remove(Area area);
        Task Update(Area area);
    }
}