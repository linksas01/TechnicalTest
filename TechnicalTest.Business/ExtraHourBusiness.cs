
using TechnicalTest.Business.Interfaces;
using TechnicalTest.Models;
using TechnicalTest.Repository.Interfaces;
using TechnicalTest.Utilities.Exceptions;
using TechnicalTest.Utilities.Configs;

namespace TechnicalTest.Business
{
    public class ExtraHourBusiness : IExtraHourBusiness
    {
        private readonly IAppConfig _config;
        private IExtraHourRepository _extraHourRepository;        

        public ExtraHourBusiness(IAppConfig config, IExtraHourRepository extraHourRepository)
        {
            _config = config;
            _extraHourRepository = extraHourRepository;
        }

        public async Task Add(ExtraHour extraHour)
        {            
            var hours = _extraHourRepository.Get().Result
                .Where(eh => eh.Date.Month == DateTime.UtcNow.Month && eh.EmployeeId.Equals(extraHour.EmployeeId))
                .Sum(eh => eh.Hours);

            if (hours + extraHour.Hours <= 40)
            {
                await _extraHourRepository.Add(extraHour);
            }
            else
            {
                throw new BusinessException(_config.MaxHours);
            }
        }

        public async Task<IEnumerable<ExtraHour>> Get()
        {
            return await _extraHourRepository.Get();
        }

        public async Task<ExtraHour?> Get(Guid id)
        {
            return await _extraHourRepository.Get(id);
        }

        public async Task Remove(ExtraHour extraHour)
        {
            await _extraHourRepository.Remove(extraHour);
        }

        public async Task Update(ExtraHour extraHour)
        {
            await _extraHourRepository.Update(extraHour);
        }
    }
}