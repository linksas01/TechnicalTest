using Microsoft.EntityFrameworkCore;
using TechnicalTest.Models;
using TechnicalTest.Repository.Interfaces;

namespace TechnicalTest.Repository
{
    public class ExtraHourRepository : IExtraHourRepository
    {
        private readonly TechnicalTestContext _dbContext;

        public ExtraHourRepository(TechnicalTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(ExtraHour extraHour)
        {
            _dbContext.ExtraHours.Add(extraHour);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExtraHour>> Get()
        {
            return await _dbContext.ExtraHours.ToListAsync();
        }

        public async Task<ExtraHour?> Get(Guid id)
        {
            return await _dbContext.ExtraHours.FindAsync(id);
        }        

        public async Task Remove(ExtraHour extraHour)
        {
            _dbContext.ExtraHours.Remove(extraHour);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(ExtraHour extraHour)
        {
            _dbContext.Entry(extraHour).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}