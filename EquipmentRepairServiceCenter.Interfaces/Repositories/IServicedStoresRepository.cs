using EquipmentRepairServiceCenter.Domain.Models;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories
{
    public interface IServicedStoresRepository
    {
        Task<IEnumerable<ServicedStore>> GetAll(bool trackChanges);
        Task<ServicedStore> GetById(Guid id, bool trackChanges);
        Task<ServicedStore> GetByNameAndAddress(string name, string address);
        Task Create(ServicedStore entity);
        void Delete(ServicedStore entity);
        void Update(ServicedStore entity);
    }
}
