using EquipmentRepairServiceCenter.Domain.Models;

namespace EquipmentRepairServiceCenter.Interfaces.Repositories
{
    public interface ISparePartsRepository
    {
        Task<IEnumerable<SparePart>> GetAll(bool trackChanges);
        Task<IEnumerable<SparePart>> Get(int rowsCount, string cacheKey);
        Task<SparePart> GetById(Guid id, bool trackChanges);
        Task Create(SparePart entity);
        void Delete(SparePart entity);
        void Update(SparePart entity);
    }
}
