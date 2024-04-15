using TechnicalTest.Business.Interfaces;
using TechnicalTest.Models;
using Enums = TechnicalTest.Models.Enums;
using TechnicalTest.Repository.Interfaces;
using TechnicalTest.Utilities.Exceptions;
using Config = TechnicalTest.Utilities.Interfaces;

namespace TechnicalTest.Business
{
    public class EmployeeBusiness : IEmployeeBusiness
    {
        private readonly Config.IAppConfig _config;
        private IEmployeeRepository _employeeRepository;

        public EmployeeBusiness(Config.IAppConfig config, IEmployeeRepository employeeRepository)
        {
            _config = config;
            _employeeRepository = employeeRepository;
        }

        public async Task Add(Employee employee)
        {
            if (!employee.LeaderId.HasValue)
            {
                if ((byte)Enums.Role.Manager == employee.RolId)
                {
                    await _employeeRepository.Add(employee);
                }
                else
                {
                    throw new BusinessException(_config.LeaderNotFound);
                }
            }
            else
            {
                await _employeeRepository.Add(employee);
            }
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            return await _employeeRepository.Get();
        }

        public async Task<Employee> Get(string email)
        {
            return await _employeeRepository.Get(email);
        }

        public async Task<Employee?> Get(Guid id)
        {
            return await _employeeRepository.Get(id);
        }

        public async Task Remove(Employee employee)
        {
            await _employeeRepository.Remove(employee);
        }

        public async Task Update(Employee employee)
        {
            await _employeeRepository.Update(employee);
        }
    }
}