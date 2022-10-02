using EquipmentRepairServiceCenter.DTO.SparePart;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EquipmentRepairServiceCenter.Interfaces.Services
{
    public interface ISparePartsService
    {
        Task<IEnumerable<SparePartDto>> GetAll();
        Task<SparePartDto> GetById(Guid id);
        Task<SparePartDto> Create(SparePartForCreationDto entityForCreation);
        Task<bool> Delete(Guid id);
        Task<bool> Update(SparePartForUpdateDto entityForUpdate);
    }
}
