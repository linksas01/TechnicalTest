using TechnicalTest.Models;

namespace TechnicalTest.Repository.Interfaces
{
    public interface IAreaRepository
    {
        Task Add(Area area);
        Task<IEnumerable<Area>> Get();
        Task<Area?> Get(byte id);
        Task Remove(Area area);
        Task Update(Area area);
    }
}