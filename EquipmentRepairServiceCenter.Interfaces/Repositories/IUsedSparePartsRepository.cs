using EquipmentRepairServiceCenter.Domain.Models;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories
{
    public interface IUsedSparePartsRepository
    {
        Task<IEnumerable<UsedSparePart>> GetAll(bool trackChanges);
        Task<IEnumerable<UsedSparePart>> Get(int rowsCount, string cacheKey);
        Task<UsedSparePart> GetById(Guid id, bool trackChanges);
        Task Create(UsedSparePart entity);
        void Delete(UsedSparePart entity);
    }
}
