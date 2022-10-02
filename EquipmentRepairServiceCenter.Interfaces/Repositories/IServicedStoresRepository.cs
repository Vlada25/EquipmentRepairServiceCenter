using EquipmentRepairServiceCenter.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories
{
    public interface IServicedStoresRepository
    {
        Task<IEnumerable<ServicedStore>> GetAll(bool trackChanges);
        Task<ServicedStore> GetById(Guid id, bool trackChanges);
        Task Create(ServicedStore entity);
        Task Create(IEnumerable<ServicedStore> entities);
        Task Delete(ServicedStore entity);
        Task Update(ServicedStore entity);
    }
}
