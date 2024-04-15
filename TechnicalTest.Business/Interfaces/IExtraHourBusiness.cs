using TechnicalTest.Models;

namespace TechnicalTest.Business.Interfaces
{
    public interface IExtraHourBusiness
    {
        Task Add(ExtraHour extraHour);
        Task<IEnumerable<ExtraHour>> Get();
        Task<ExtraHour?> Get(Guid id);
        Task Remove(ExtraHour extraHour);
        Task Update(ExtraHour extraHour);
    }
}