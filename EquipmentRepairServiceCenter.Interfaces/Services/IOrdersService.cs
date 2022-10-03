using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Interfaces.Services
{
    public interface IOrdersService
    {
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(Guid id);
        Task<Order> Create(OrderForCreationDto entityForCreation);
        Task CreateMany();
        Task<bool> Delete(Guid id);
        Task<bool> Update(OrderForUpdateDto entityForUpdate);
    }
}
