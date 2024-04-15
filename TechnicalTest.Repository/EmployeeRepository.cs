using Microsoft.EntityFrameworkCore;
using TechnicalTest.Models;
using TechnicalTest.Repository.Interfaces;

namespace TechnicalTest.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly TechnicalTestContext _dbContext;

        public EmployeeRepository(TechnicalTestContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await _dbContext.Employees.ToListAsync();
        }

        public async Task<Employee> Get(string email)
        {
            return await _dbContext.Employees.FirstAsync(e => email.Equals(e.Email));
        }

        public async Task<Employee?> Get(Guid id)
        {
            return await _dbContext.Employees.FindAsync(id);
        }        

        public async Task Remove(Employee employee)
        {
            _dbContext.Employees.Remove(employee);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {
            _dbContext.Entry(employee).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}