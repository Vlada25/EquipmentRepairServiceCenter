using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.Fault;

namespace EquipmentRepairServiceCenter.Interfaces.Services
{
    public interface IFaultsService
    {
        Task<IEnumerable<Fault>> GetAll();
        Task<IEnumerable<Fault>> Get(int rowsCount, string cacheKey);
        Task<Fault> GetById(Guid id);
        Task<Fault> Create(FaultForCreationDto entityForCreation);
        Task<bool> Delete(Guid id);
        Task<bool> Update(FaultForUpdateDto entityForUpdate);
    }
}
