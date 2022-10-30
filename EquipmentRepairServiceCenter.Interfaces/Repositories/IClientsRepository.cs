using EquipmentRepairServiceCenter.Domain.Models.People;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories
{
    public interface IClientsRepository
    {
        Task<IEnumerable<Client>> GetAll(bool trackChanges);
        Task<Client> GetById(Guid id, bool trackChanges);
        Task<Client> GetByUserId(Guid userId, bool trackChanges);
        Task Create(Client entity);
        void Delete(Client entity);
        void Update(Client entity);
    }
}
