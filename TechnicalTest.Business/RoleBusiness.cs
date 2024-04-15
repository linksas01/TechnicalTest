using TechnicalTest.Business.Interfaces;
using TechnicalTest.Models;
using TechnicalTest.Repository.Interfaces;

namespace TechnicalTest.Business
{
    public class RoleBusiness : IRoleBusiness
    {
        private IRoleRepository _roleRepository;

        public RoleBusiness(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }
        public async Task Add(Role role)
        {
            await _roleRepository.Add(role);
        }       

        public async Task<IEnumerable<Role>> Get()
        {
            return await _roleRepository.Get();
        }

        public async Task<Role?> Get(byte id)
        {
            return await _roleRepository.Get(id);
        }

        public async Task Remove(Role role)
        {
            await _roleRepository.Remove(role);
        }

        public async Task Update(Role role)
        {
            await _roleRepository.Update(role);
        }
    }
}