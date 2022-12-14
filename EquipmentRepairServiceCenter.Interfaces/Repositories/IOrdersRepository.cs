using EquipmentRepairServiceCenter.Domain.Models;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Order>> GetAll(bool trackChanges);
        Task<IEnumerable<Order>> Get(int rowsCount, string cacheKey);
        Task<IEnumerable<Order>> GetByEmployeeId(Guid employeeId);
        Task<IEnumerable<Order>> GetByClientId(Guid clientId);
        Task<Order> GetById(Guid id, bool trackChanges);
        Task Create(Order entity);
        void Delete(Order entity);
        void Update(Order entity);
    }
}
