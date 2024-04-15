using Microsoft.EntityFrameworkCore;
using TechnicalTest.Models;
using TechnicalTest.Repository.Interfaces;

namespace TechnicalTest.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly TechnicalTestContext _dbContext;

        public RoleRepository(TechnicalTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Role role)
        {
            _dbContext.Roles.Add(role);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Role>> Get()
        {
            return await _dbContext.Roles.ToListAsync();
        }

        public async Task<Role?> Get(byte id)
        {
            return await _dbContext.Roles.FindAsync(id);
        }

        public async Task Remove(Role role)
        {
            _dbContext.Roles.Remove(role);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Role role)
        {
            _dbContext.Entry(role).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}