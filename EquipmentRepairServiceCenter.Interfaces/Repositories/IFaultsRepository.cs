using EquipmentRepairServiceCenter.Domain.Models;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories
{
    public interface IFaultsRepository
    {
        Task<IEnumerable<Fault>> GetAll(bool trackChanges);
        Task<IEnumerable<Fault>> Get(int rowsCount, string cacheKey);
        Task<Fault> GetById(Guid id, bool trackChanges);
        Task Create(Fault entity);
        void Delete(Fault entity);
        void Update(Fault entity);
    }
}
