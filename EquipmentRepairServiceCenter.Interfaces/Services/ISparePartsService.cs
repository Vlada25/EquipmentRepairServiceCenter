using EquipmentRepairServiceCenter.DTO.SparePart;

namespace EquipmentRepairServiceCenter.Interfaces.Services
{
    public interface ISparePartsService
    {
        Task<IEnumerable<SparePartDto>> GetAll();
        Task<IEnumerable<SparePartDto>> Get(int rowsCount, string cacheKey);
        Task<SparePartDto> GetById(Guid id);
        Task<SparePartDto> Create(SparePartForCreationDto entityForCreation);
        Task<bool> Delete(Guid id);
        Task<bool> Update(SparePartForUpdateDto entityForUpdate);
    }
}
