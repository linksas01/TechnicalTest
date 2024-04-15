using TechnicalTest.Models;

namespace TechnicalTest.Business.Interfaces
{
    public interface IEmployeeBusiness
    {
        Task Add(Employee employee);
        Task<IEnumerable<Employee>> Get();
        Task<Employee> Get(string email);
        Task<Employee?> Get(Guid id);        
        Task Remove(Employee employee);
        Task Update(Employee employee);
    }
}