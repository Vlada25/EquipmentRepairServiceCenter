using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.ServicedStore;

namespace EquipmentRepairServiceCenter.Interfaces.Services
{
    public interface IServicedStoresService
    {
        Task<IEnumerable<ServicedStore>> GetAll();
        Task<ServicedStore> GetById(Guid id);
        Task<ServicedStore> GetByNameAndAddress(string name, string address);
        Task<ServicedStore> Create(ServicedStoreForCreationDto entityForCreation);
        Task<bool> Delete(Guid id);
        Task<bool> Update(ServicedStoreForUpdateDto entityForUpdate);
    }
}
