using EquipmentRepairServiceCenter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories
{
    public interface IOrdersRepository
    {
        Task<IEnumerable<Order>> GetAll(bool trackChanges);
        Task<Order> GetById(Guid id, bool trackChanges);
        Task Create(Order entity);
        void Delete(Order entity);
        void Update(Order entity);
    }
}
