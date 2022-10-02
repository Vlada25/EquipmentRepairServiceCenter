using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.ServicedStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Interfaces.Services
{
    public interface IServicedStoresService
    {
        Task<IEnumerable<ServicedStore>> GetAll();
        Task<ServicedStore> GetById(Guid id);
        Task<ServicedStore> Create(ServicedStoreForCreationDto entityForCreation);
        Task<bool> Delete(Guid id);
        Task<bool> Update(ServicedStoreForUpdateDto entityForUpdate);
    }
}
