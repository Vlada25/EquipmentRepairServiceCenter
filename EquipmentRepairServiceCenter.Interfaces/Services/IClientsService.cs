using EquipmentRepairServiceCenter.Domain.Models.People;
using EquipmentRepairServiceCenter.DTO.Client;

namespace EquipmentRepairServiceCenter.Interfaces.Services
{
    public interface IClientsService
    {
        Task<IEnumerable<Client>> GetAll();
        Task<IEnumerable<Client>> Get(int rowsCount, string cacheKey);
        Task<Client> GetById(Guid id);
        Task<Client> GetByUserId(Guid userId);
        Task<Client> Create(ClientForCreationDto entityForCreation);
        Task CreateByUsers();
        Task<bool> Delete(Guid id);
        Task<bool> Update(ClientForUpdateDto entityForUpdate);
    }
}
