using TechnicalTest.Models;

namespace TechnicalTest.Repository.Interfaces
{
    public interface IRoleRepository
    {
        Task Add(Role role);
        Task<IEnumerable<Role>> Get();
        Task<Role?> Get(byte id);
        Task Remove(Role role);
        Task Update(Role role);
    }
}