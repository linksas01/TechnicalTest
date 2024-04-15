using TechnicalTest.Models;

namespace TechnicalTest.Repository.Interfaces
{
    public interface IExtraHourRepository
    {
        Task Add(ExtraHour extraHour);
        Task<IEnumerable<ExtraHour>> Get();
        Task<ExtraHour?> Get(Guid id);        
        Task Remove(ExtraHour extraHour);
        Task Update(ExtraHour extraHour);
    }
}