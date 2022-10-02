using EquipmentRepairServiceCenter.Domain.Models;
using EquipmentRepairServiceCenter.DTO.RepairingModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
