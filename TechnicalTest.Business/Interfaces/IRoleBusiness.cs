using TechnicalTest.Models;

namespace TechnicalTest.Business.Interfaces
{
    public interface IRoleBusiness
    {
        Task Add(Role role);
        Task<IEnumerable<Role>> Get();
        Task<Role?> Get(byte id);
        Task Remove(Role role);
        Task Update(Role role);
    }
}