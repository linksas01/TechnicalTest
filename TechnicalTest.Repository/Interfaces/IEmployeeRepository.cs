using TechnicalTest.Models;

namespace TechnicalTest.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        Task Add(Employee employee);
        Task<IEnumerable<Employee>> Get();
        Task<Employee> Get(string email);
        Task<Employee?> Get(Guid id);        
        Task Remove(Employee employee);
        Task Update(Employee employee);
    }
}