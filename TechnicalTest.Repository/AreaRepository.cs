using Microsoft.EntityFrameworkCore;
using TechnicalTest.Models;
using TechnicalTest.Repository.Interfaces;

namespace TechnicalTest.Repository
{
    public class AreaRepository : IAreaRepository
    {
        private readonly TechnicalTestContext _dbContext;

        public AreaRepository(TechnicalTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Area area)
        {
            _dbContext.Areas.Add(area);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Area>> Get()
        {
            return await _dbContext.Areas.ToListAsync();
        }

        public async Task<Area?> Get(byte id)
        {
            return await _dbContext.Areas.FindAsync(id);
        }

        public async Task Remove(Area area)
        {
            _dbContext.Areas.Remove(area);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Area area)
        {
            _dbContext.Entry(area).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}