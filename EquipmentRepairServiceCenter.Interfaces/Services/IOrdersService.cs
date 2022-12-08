using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.Order;

namespace EquipmentRepairServiceCenter.Interfaces.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<Order>> GetAll();
        Task<IEnumerable<Order>> Get(int rowsCount, string cacheKey);
        Task<IEnumerable<Order>> GetByEmployeeId(Guid employeeId);
        Task<IEnumerable<Order>> GetByClientId(Guid clientId);
        Task<Order> GetById(Guid id);
        Task<Order> Create(OrderForCreationDto entityForCreation);
        Task CreateMany();
        Task<bool> Delete(Guid id);
        Task<bool> Update(OrderForUpdateDto entityForUpdate);
    }
}
