using EquipmentRepairServiceCenter.DTO.RepairingModel;

namespace EquipmentRepairServiceCenter.Interfaces.Services
{
    public interface IRepairingModelsService
    {
        Task<IEnumerable<RepairingModelDto>> GetAll();
        Task<RepairingModelDto> GetById(Guid id);
        Task<RepairingModelDto> Create(RepairingModelForCreationDto entityForCreation);
        Task<bool> Delete(Guid id);
        Task<bool> Update(RepairingModelForUpdateDto entityForUpdate);
    }
}
