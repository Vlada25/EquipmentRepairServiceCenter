using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.Order;

namespace EquipmentRepairServiceCenter.Interfaces.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<Order>> GetAll();
        Task<IEnumerable<Order>> GetByEmployeeId(Guid employeeId);
        Task<Order> GetById(Guid id);
        Task<Order> Create(OrderForCreationDto entityForCreation);
        Task CreateMany();
        Task<bool> Delete(Guid id);
        Task<bool> Update(OrderForUpdateDto entityForUpdate);
    }
}
