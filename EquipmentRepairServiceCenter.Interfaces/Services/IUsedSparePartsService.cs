using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.UsedSparePart;

namespace EquipmentRepairServiceCenter.Interfaces.Services
{
    public interface IUsedSparePartsService
    {
        Task<IEnumerable<UsedSparePart>> GetAll();
        Task<IEnumerable<UsedSparePart>> Get(int rowsCount, string cacheKey);
        Task<UsedSparePart> GetById(Guid id);
        Task<UsedSparePart> Create(UsedSparePartForCreationDto entityForCreation);
        Task<bool> Delete(Guid id);
    }
}
